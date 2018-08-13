using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoAudioListener.AppSettings;
using System.Diagnostics;
using NAudio.CoreAudioApi;

namespace AutoAudioListener {
    public partial class ProfileEditForm : Form {

        private readonly Dictionary<string, ProcessPriorityClass> ProcessPriority = new Dictionary<string, ProcessPriorityClass>{
            { "Normal", ProcessPriorityClass.Normal },
            { "Above Normal (Recommended)", ProcessPriorityClass.AboveNormal },
            { "High (Low Latency Support)", ProcessPriorityClass.High },
            { "RealTime (Not Recommeneded)", ProcessPriorityClass.RealTime }
        };

        public ProfileEditForm(CustomProfile workingProfile) {
            InitializeComponent();
            ChangeWorkingProfile(workingProfile);
        }

        public CustomProfile WorkingProfile { get; private set; }

        public bool Dirty { get; private set; } = true;

        private WasapiCapture _monitoringCapture;
        private MMDevice _monitoringDevice;
        private MMDevice MonitoringDevice {
            get {
                if (_monitoringDevice == null && WorkingProfile != null) {
                    using (var devices = new MMDeviceEnumerator()) {
                        _monitoringDevice = devices.GetDevice(WorkingProfile.ActiveListenerFormat.InputDeviceID);
                        _monitoringCapture = new WasapiCapture(_monitoringDevice);
                        _monitoringCapture.StartRecording();
                    }
                }
                return _monitoringDevice;
            }
            set {
                _monitoringCapture?.StopRecording();
                _monitoringCapture?.Dispose();
                _monitoringDevice?.Dispose();
                if (value != null) {
                    _monitoringCapture = new WasapiCapture(_monitoringDevice);
                    _monitoringCapture.StartRecording();
                }
            }
        }

        public void ChangeWorkingProfile(CustomProfile workingProfile) {
            this.WorkingProfile = workingProfile;
            BindProfileData();
        }

        private void BindProfileData() {
            this.Text = $"Edit Profile - [{WorkingProfile.Name}]";
            noiseFloorValueBox.DataBindings.Clear();
            noiseFloorValueBox.DataBindings.Add("Value", WorkingProfile.ActiveListenerFormat, "SlienceLevel", false, DataSourceUpdateMode.OnPropertyChanged);
            activeLevelValueBox.DataBindings.Clear();
            activeLevelValueBox.DataBindings.Add("Value", WorkingProfile.ActiveListenerFormat, "ActiveLevel", false, DataSourceUpdateMode.OnPropertyChanged);
            inputLatencyValueBox.DataBindings.Clear();
            inputLatencyValueBox.DataBindings.Add("Value", WorkingProfile.ActiveListenerFormat, "PreferredInputLatency", false, DataSourceUpdateMode.OnPropertyChanged);
            outputLatencyValueBox.DataBindings.Clear();
            outputLatencyValueBox.DataBindings.Add("Value", WorkingProfile.ActiveListenerFormat, "PreferredOutputLatency", false, DataSourceUpdateMode.OnPropertyChanged);
            timeoutValueBox.DataBindings.Clear();
            timeoutValueBox.DataBindings.Add("Value", WorkingProfile.ActiveListenerFormat, "ActiveTimeoutMilliseconds", false, DataSourceUpdateMode.OnPropertyChanged);
            priorityComboBox.DataSource = new BindingSource(ProcessPriority, null);
            priorityComboBox.DisplayMember = "Key";
            priorityComboBox.ValueMember = "Value";
            priorityComboBox.SelectedItem = ProcessPriority.First(s => s.Value == WorkingProfile.AppPriority);
            noiseFloorSensitivityControl.SetMonitoringDevice(MonitoringDevice);
            noiseFloorSensitivityControl.SetValue(WorkingProfile.ActiveListenerFormat.SlienceLevel);
            activeLevelSensitivityControl.SetMonitoringDevice(MonitoringDevice);
            activeLevelSensitivityControl.SetValue(WorkingProfile.ActiveListenerFormat.ActiveLevel);
        }

        private bool SaveProfile() {
            if (WorkingProfile.ValidateData()) {
                WorkingProfile.SaveChanges();
                return true;
            } else {
                MessageBox.Show("Some field you've inputted is invalid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e) {
            if (SaveProfile()) {
                Dirty = false;
                this.Close();
            }
        }

        private void RestoreDefaultButton_Click(object sender, EventArgs e) {
            WorkingProfile.RestoreDefault();
            BindProfileData();
        }

        private void priorityComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            WorkingProfile.AppPriority = (ProcessPriorityClass)priorityComboBox.SelectedValue;
        }

        private void ProfileEditForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (Dirty) {
                SavePrompt(e);
            }
            if (!e.Cancel) {
                DisposeResources();
            }
        }

        private void SavePrompt(FormClosingEventArgs e) {
            var result = MessageBox.Show("Save changes?", "Edit Profile", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (result) {
                case DialogResult.Yes:
                    if (!SaveProfile()) e.Cancel = true;
                    break;
                case DialogResult.No:
                    WorkingProfile.DiscardChanges();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        private void DisposeResources() {
            noiseFloorSensitivityControl.StopMonitoring();
            activeLevelSensitivityControl.StopMonitoring();
            MonitoringDevice = null;
        }

        private void noiseFloorSensitivityControl_ValueChanged(object sender, EventArgs e) {
            noiseFloorValueBox.Value = (decimal)noiseFloorSensitivityControl.Value; 
        }

        private void activeLevelSensitivityControl_ValueChanged(object sender, EventArgs e) {
            activeLevelValueBox.Value = (decimal)activeLevelSensitivityControl.Value;
        }

        private void noiseFloorValueBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                noiseFloorSensitivityControl.SetValue((float)noiseFloorValueBox.Value);
                e.Handled = true;
            }
        }

        private void activeLevelValueBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                activeLevelSensitivityControl.SetValue((float)activeLevelValueBox.Value);
                e.Handled = true;
            }
        }
    }
}
