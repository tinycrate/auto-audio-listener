using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AutoAudioListener.AppSettings;
using AutoAudioListener.Audio;
using AutoAudioListener.Properties;
using AutoAudioListener.Utils;
using AutoAudioListener.Utils.Debug;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace AutoAudioListener {
    public partial class MainForm : Form {
        private AudioListener _mainaudioListener;

        public MainForm() {
            CheckRunningEnvironment();
            InitializeComponent();
            SetUpIcons();
            BindDataSources();
            RestoreFormPositionFromPreferences();
            RestoreSelectedProfileFromPreferences();
            RestoreSelectedDevicesFromProfile();
        }

        private AudioListener MainAudioListener {
            get => _mainaudioListener;
            set {
                if (_mainaudioListener != null) {
                    _mainaudioListener.Dispose();
                }
                _mainaudioListener = value;
            }
        }

        public SimpleMessageLogger EventHistory { get; set; } = new SimpleMessageLogger("hh:mm:ss:fff");

        private static void CheckRunningEnvironment() {
            using (var devices = new MMDeviceEnumerator()) {
                if (devices.HasDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia) &&
                    devices.HasDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia)) {
                    return;
                }
                MessageBox.Show(
                    "No audio recording or playback found on this device. The application will now exit.",
                    "Critical Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Environment.Exit(1);
            }
        }

        private void SetUpIcons() {
            var icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Icon = icon;
            trayIcon.Icon = icon;
        }

        private void RestoreFormPositionFromPreferences() {
            var lastFormPosition = new Point(Settings.Default.LastMainFormPosX, Settings.Default.LastMainFormPosY);
            if (!IsOnScreen(lastFormPosition)) return;
            StartPosition = FormStartPosition.Manual;
            Location = lastFormPosition;
        }

        private void UpdateFormPositionPreferences() {
            if (Location.X >= 0 && Location.Y >= 0) {
                Settings.Default.LastMainFormPosX = Location.X;
                Settings.Default.LastMainFormPosY = Location.Y;
            }
        }

        private void UpdateAndSaveFormPositionPreferences() {
            UpdateFormPositionPreferences();
            Settings.Default.Save();
        }

        private void RestoreSelectedProfileFromPreferences() {
            var selectedProfileID = Settings.Default.SelectedProfileID;
            var profileIndex = CustomProfile.EnumerateProfiles().ToList()
                .FindIndex(profile => profile.Id == selectedProfileID);
            if (profileIndex >= 0) profileComboBox.SelectedIndex = profileIndex;
        }

        private void SaveSelectedProfileToPreferences() {
            Settings.Default.SelectedProfileID = ((CustomProfile) profileComboBox.SelectedItem).Id;
            Settings.Default.Save();
        }

        private void RestoreSelectedDevicesFromProfile() {
            var inputDeviceID = ((Profile) profileComboBox.SelectedItem).ListenerFormat.InputDeviceID;
            var outputDeviceID = ((Profile) profileComboBox.SelectedItem).ListenerFormat.OutputDeviceID;
            var inputDevices = (List<MMDevice>) inputDeviceComboBox.DataSource;
            var outputDevices = (List<MMDevice>) outputDeviceComboBox.DataSource;
            var inputDeviceIndex = inputDevices.FindIndex(device => device.ID == inputDeviceID);
            var outputDeviceIndex = outputDevices.FindIndex(device => device.ID == outputDeviceID);
            if (inputDeviceIndex >= 0) inputDeviceComboBox.SelectedIndex = inputDeviceIndex;
            if (outputDeviceIndex >= 0) outputDeviceComboBox.SelectedIndex = outputDeviceIndex;
        }

        private void SetupAutostart() {
            LogEventHistory("App successfully launched at Windows startup!");
            WindowState = FormWindowState.Minimized;
            StartListening();
        }

        private void SaveListenerFormatToProfile(AudioListenerFormat format) {
            var profile = (CustomProfile) profileComboBox.SelectedItem;
            profile.ListenerFormat = format;
            profile.SaveChanges();
        }

        private bool IsOnScreen(Point lastFormPosition) {
            foreach (var screen in Screen.AllScreens) {
                var formTopLeftArea = new Rectangle(lastFormPosition, new Size(30, 30));
                if (screen.WorkingArea.Contains(formTopLeftArea)) {
                    return true;
                }
            }
            return false;
        }

        private void SetUpAudioListener() {
            var profile = (Profile) profileComboBox.SelectedItem;
            var inputDevice = (MMDevice) inputDeviceComboBox.SelectedItem;
            var outputDevice = (MMDevice) outputDeviceComboBox.SelectedItem;
            var activeListenerFormat = profile.ListenerFormat;
            activeListenerFormat.InputDeviceID = inputDevice.ID;
            activeListenerFormat.OutputDeviceID = outputDevice.ID;
            MainAudioListener = new AudioListener(activeListenerFormat, this);
            Process.GetCurrentProcess().PriorityClass = profile.AppPriority;
            LogListeningStatus(profile, inputDevice, outputDevice, activeListenerFormat);
            SubscribeListenerEvents();
            SaveListenerFormatToProfile(activeListenerFormat);
            SaveSelectedProfileToPreferences();
        }

        private void LogListeningStatus(
            Profile profile,
            MMDevice inputDevice,
            MMDevice outputDevice,
            AudioListenerFormat listenerFormat
        ) {
            LogEventHistory($"Main Audio Listener is set using profile {profile.Name}:");
            LogEventHistory($"  >Input device: {inputDevice.FriendlyName}");
            LogEventHistory($"  >Output device: {outputDevice.FriendlyName}");
            LogEventHistory($"  >Preferred Input Latency: {listenerFormat.PreferredInputLatency}");
            LogEventHistory($"  >Preferred Output Latency: {listenerFormat.PreferredOutputLatency}");
            LogEventHistory($"  >Slience Level:  {listenerFormat.SilenceLevel}");
            LogEventHistory($"  >Active Level: {listenerFormat.ActiveLevel}");
            LogEventHistory($"  >Active Timeout Milliseconds: {listenerFormat.ActiveTimeoutMilliseconds}");
            LogEventHistory($"  >Process Pirority: {profile.AppPriority.ToString()}");
        }

        private void SubscribeListenerEvents() {
            MainAudioListener.OutputVolumeUpdated += MainAudioListener_OutputVolumeUpdated;
            MainAudioListener.OutputVolumeChanged += MainAudioListener_OutputVolumeChanged;
            MainAudioListener.AudioActivated += MainAudioListener_AudioActivated;
            MainAudioListener.AudioDeactivated += MainAudioListener_AudioDeactivated;
            MainAudioListener.ListeningStopped += MainAudioListener_ListeningStopped;
            //MainAudioListener.BufferVolumeTriggered += MainAudioListener_BufferVolumeTriggered;
        }

        private void BindDataSources() {
            BindIODevicesList();
            BindProfileList();
            BindRunOnStartupSetting();
        }

        private void BindIODevicesList() {
            MMDeviceCollection inputDevices, outputDevices;
            using (var devices = new MMDeviceEnumerator()) {
                inputDevices = devices.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
                outputDevices = devices.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            }
            inputDeviceComboBox.DataSource = null;
            inputDeviceComboBox.DataSource = inputDevices.ToList();
            inputDeviceComboBox.DisplayMember = "FriendlyName";
            outputDeviceComboBox.DataSource = null;
            outputDeviceComboBox.DataSource = outputDevices.ToList();
            outputDeviceComboBox.DisplayMember = "FriendlyName";
        }

        private void BindProfileList() {
            profileComboBox.DataSource = null;
            profileComboBox.DataSource =
                CustomProfile.EnumerateProfiles().OrderByDescending(x => x.DateModified).ToList();
            profileComboBox.DisplayMember = "Name";
        }

        private void BindRunOnStartupSetting() {
            runAtStartupCheckBox.Checked = AutoStartup.Enabled;
        }

        private void StartListening() {
            startStopListeningButton.Text = "Stop Listening";
            startStopListeningButton.Refresh();
            SetUpAudioListener();
            MainAudioListener.StartListening();
            LogEventHistory("Listening started.");
            UpdateStatusBar("Started Listening...");
        }

        private void StopListening() {
            MainAudioListener.StopListening();
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
            startStopListeningButton.Text = "Start Listening";
            LogEventHistory("Listening stopped.");
            UpdateStatusBar("Listening stopped.");
        }

        private void OpenEventLogsForm() {
            var logsForm = Application.OpenForms.OfType<EventLogsForm>().FirstOrDefault();
            if (logsForm == null) {
                logsForm = new EventLogsForm(EventHistory.Messages);
                logsForm.Show();
            } else {
                logsForm.Focus();
            }
        }

        private void OpenEditForm() {
            var profile = (CustomProfile) profileComboBox.SelectedItem;
            var editForm = new ProfileEditForm(profile);
            editForm.ShowDialog();
        }

        private void ResetVolumeControls() {
            leftVolumeBar.Value = 0;
            rightVolumeBar.Value = 0;
        }

        private void LogEventHistory(string message) {
            EventHistory.Add(message);
        }

        private void UpdateStatusBar(string message) {
            statusLabel.Text = $"[{DateTime.Now.ToString("hh:mm:ss")}]: {message}";
        }

        private void MainAudioListener_AudioActivated(object sender, EventArgs e) {
            LogEventHistory($"Audio Activated at source volume {MainAudioListener.CurrentSourceVolume}.");
            UpdateStatusBar("Audio Activated.");
        }

        private void MainAudioListener_AudioDeactivated(object sender, EventArgs e) {
            LogEventHistory("Audio Deactivated");
            UpdateStatusBar("Audio Deactivated.");
        }

        private void MainAudioListener_OutputVolumeUpdated(object sender, EventArgs e) {
            var currentSourceVolumeLeft = MainAudioListener.CurrentSourceVolumeLeft;
            var currentSourceVolumeRight = MainAudioListener.CurrentSourceVolumeRight;
            leftVolumeBar.Value = (int) (currentSourceVolumeLeft * 1000);
            rightVolumeBar.Value = (int) (currentSourceVolumeRight * 1000);
        }

        private void MainAudioListener_OutputVolumeChanged(object sender, EventArgs e) { }

        private void MainAudioListener_BufferVolumeTriggered(object sender, EventArgs e) {
            LogEventHistory(
                $"Buffer volume triggered at source volume {MainAudioListener.CurrentSourceVolume}. Fading output volume to {MainAudioListener.CurrentOutputVolume}."
            );
        }

        private void MainAudioListener_ListeningStopped(object sender, StoppedEventArgs e) {
            ResetVolumeControls();
        }

        private void MainForm_Move(object sender, EventArgs e) {
            UpdateFormPositionPreferences();
        }

        private void MainForm_Resize(object sender, EventArgs e) {
            if (FormWindowState.Minimized == WindowState) {
                Hide();
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (FormWindowState.Minimized == WindowState) {
                Show();
                WindowState = FormWindowState.Normal;
            } else {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void startStopListeningButton_Click(object sender, EventArgs e) {
            if (MainAudioListener != null && MainAudioListener.Listening) {
                StopListening();
            } else {
                StartListening();
            }
        }

        private void viewLogsButton_Click(object sender, EventArgs e) {
            OpenEventLogsForm();
        }

        private void runAtStartupCheckBox_CheckedChanged(object sender, EventArgs e) {
            AutoStartup.Enabled = runAtStartupCheckBox.Checked;
        }

        private void profileComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            RestoreSelectedDevicesFromProfile();
        }

        private void MainForm_Shown(object sender, EventArgs e) {
            if (AutoStartup.IsLaunchedFromAutostart) SetupAutostart();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            MainAudioListener?.Dispose();
            UpdateAndSaveFormPositionPreferences();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void addProfileButton_Click(object sender, EventArgs e) {
            var newProfileId = CustomProfile.NewProfileFromDefault().Id;
            BindProfileList();
            profileComboBox.SelectedItem = profileComboBox.Items.Cast<CustomProfile>().First(x => x.Id == newProfileId);
            profileComboBox.Focus();
            OpenEditForm();
        }

        private void editProfileButton_Click(object sender, EventArgs e) {
            OpenEditForm();
        }

        private void deleteProfileButton_Click(object sender, EventArgs e) {
            CustomProfile.DeleteProfile((CustomProfile) profileComboBox.SelectedItem);
            if (profileComboBox.Items.Count <= 1) {
                CustomProfile.CreateDefaultProfile();
            }
            BindProfileList();
        }
    }
}