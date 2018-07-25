using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using AutoAudioListener.Audio;
using AutoAudioListener.Utils;
using AutoAudioListener.Utils.Debug;
using AutoAudioListener.Controls;
using AutoAudioListener.AppSettings;
using System.Diagnostics;

namespace AutoAudioListener {
    public partial class MainForm : Form {

        private ActiveAudioListener _mainaudioListener;
        private ActiveAudioListener MainAudioListener {
            get {
                return _mainaudioListener;
            }
            set {
                if (_mainaudioListener != null) {
                    _mainaudioListener.Dispose();
                }
                _mainaudioListener = value;
            }
        }

        public TimestampMessageLogger EventHistory { get; set; } = new TimestampMessageLogger("hh:mm:ss:fff");
        
        public MainForm() {
            InitializeComponent();
            SetUpIcons();
            BindDataSources();
            RestoreFormPositionFromPreferences();
            RestoreSelectedProfileFromPreferences();
            RestoreSelectedDevicesFromProfile();
        }

        private void SetUpIcons() {
            var icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.Icon = icon;
            trayIcon.Icon = icon;
        }

        private void RestoreFormPositionFromPreferences() {
            var lastFormPosition = new Point(Properties.Settings.Default.LastMainFormPosX, Properties.Settings.Default.LastMainFormPosY);
            if (!IsOnScreen(lastFormPosition)) return;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = lastFormPosition;
        }

        private void UpdateFormPositionPreferences() {
            if (this.Location.X >= 0 && this.Location.Y >= 0) {
                Properties.Settings.Default.LastMainFormPosX = this.Location.X;
                Properties.Settings.Default.LastMainFormPosY = this.Location.Y;
            }
        }

        private void UpdateAndSaveFormPositionPreferences() {
            UpdateFormPositionPreferences();
            Properties.Settings.Default.Save();
        }

        private void RestoreSelectedProfileFromPreferences() {
            string selectedProfileID = Properties.Settings.Default.SelectedProfileID;
            int profileIndex = CustomProfile.EnumerateProfiles().ToList().FindIndex(profile => profile.Id == selectedProfileID);
            if (profileIndex >= 0) profileComboBox.SelectedIndex = profileIndex; 
        }

        private void SaveSelectedProfileToPreferences() {
            Properties.Settings.Default.SelectedProfileID = ((CustomProfile)profileComboBox.SelectedItem).Id;
            Properties.Settings.Default.Save();
        }

        private void RestoreSelectedDevicesFromProfile() {
            string inputDeviceID = ((Profile)profileComboBox.SelectedItem).ActiveListenerFormat.inputDeviceID;
            string outputDeviceID = ((Profile)profileComboBox.SelectedItem).ActiveListenerFormat.outputDeviceID;
            var inputDevices = (List<MMDevice>)inputDeviceComboBox.DataSource;
            var outputDevices = (List<MMDevice>)outputDeviceComboBox.DataSource;
            int inputDeviceIndex = inputDevices.FindIndex(device => device.ID == inputDeviceID);
            int outputDeviceIndex = outputDevices.FindIndex(device => device.ID == outputDeviceID);
            if (inputDeviceIndex >= 0) inputDeviceComboBox.SelectedIndex = inputDeviceIndex;
            if (outputDeviceIndex >= 0) outputDeviceComboBox.SelectedIndex = outputDeviceIndex;
        }

        private void SetupAutostart() {
            LogEventHistory("App successfully launched at Windows startup!");
            this.WindowState = FormWindowState.Minimized;
            StartListening();
        }

        private void SaveListenerFormatToProfile(ActiveAudioListenerFormat format) {
            var profile = (CustomProfile)profileComboBox.SelectedItem;
            profile.ActiveListenerFormat = format;
            profile.SaveChanges();
        }

        private bool IsOnScreen(Point lastFormPosition) {
            foreach (Screen screen in Screen.AllScreens) {
                Rectangle formTopLeftArea = new Rectangle(lastFormPosition, new Size(30, 30));
                if (screen.WorkingArea.Contains(formTopLeftArea)) {
                    return true;
                }
            }
            return false;
        }

        private void SetUpAudioListener() {
            var profile = (Profile)profileComboBox.SelectedItem;
            var inputDevice = (MMDevice)inputDeviceComboBox.SelectedItem;
            var outputDevice = (MMDevice)outputDeviceComboBox.SelectedItem;
            var activeListenerFormat = profile.ActiveListenerFormat;
            activeListenerFormat.inputDeviceID = inputDevice.ID;
            activeListenerFormat.outputDeviceID = outputDevice.ID;
            MainAudioListener = new ActiveAudioListener(activeListenerFormat, this);
            Process.GetCurrentProcess().PriorityClass = profile.AppPriority;
            LogListeningStatus(profile, inputDevice, outputDevice, activeListenerFormat);
            SubscribeListenerEvents();
            SaveListenerFormatToProfile(activeListenerFormat);
            SaveSelectedProfileToPreferences();
        }

        private void LogListeningStatus(Profile profile, MMDevice inputDevice, MMDevice outputDevice, ActiveAudioListenerFormat activeListenerFormat) {
            LogEventHistory($"Main Audio Listener is set using profile { profile.Name }:");
            LogEventHistory($"  >Input device: { inputDevice.FriendlyName }");
            LogEventHistory($"  >Output device: { outputDevice.FriendlyName }");
            LogEventHistory($"  >Preferred Input Latency: { activeListenerFormat.preferredInputLatency }");
            LogEventHistory($"  >Preferred Output Latency: { activeListenerFormat.preferredOutputLatency }");
            LogEventHistory($"  >Slience Level:  { activeListenerFormat.SlienceLevel }");
            LogEventHistory($"  >Active Level: { activeListenerFormat.ActiveLevel }");
            LogEventHistory($"  >Active Timeout Milliseconds: { activeListenerFormat.ActiveTimeoutMilliseconds }");
            LogEventHistory($"  >Process Pirority: { profile.AppPriority.ToString() }");
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
            profileComboBox.DataSource = CustomProfile.EnumerateProfiles().ToList();
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
            LogEventHistory($"Listening stopped.");
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
            float currentSourceVolumeLeft = MainAudioListener.CurrentSourceVolumeLeft;
            float currentSourceVolumeRight = MainAudioListener.CurrentSourceVolumeRight;
            leftVolumeBar.Value = (int)(currentSourceVolumeLeft * 1000);
            rightVolumeBar.Value = (int)(currentSourceVolumeRight * 1000);
        }

        private void MainAudioListener_OutputVolumeChanged(object sender, EventArgs e) {
        }

        private void MainAudioListener_BufferVolumeTriggered(object sender, EventArgs e) {
            LogEventHistory($"Buffer volume triggered at source volume {MainAudioListener.CurrentSourceVolume}. Fading output volume to {MainAudioListener.CurrentOutputVolume}.");
        }

        private void MainAudioListener_ListeningStopped(object sender, NAudio.Wave.StoppedEventArgs e) {
            ResetVolumeControls();
        }

        private void MainForm_Move(object sender, EventArgs e) {
            UpdateFormPositionPreferences();
        }

        private void MainForm_Resize(object sender, EventArgs e) {
            if (FormWindowState.Minimized == this.WindowState) {
                this.Hide();
            }
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (FormWindowState.Minimized == this.WindowState) {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            } else {
                this.WindowState = FormWindowState.Minimized;
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
            MessageBox.Show("Not Implemented!");
        }

        private void editProfileButton_Click(object sender, EventArgs e) {
            MessageBox.Show("Not Implemented!");
        }
    }
}
