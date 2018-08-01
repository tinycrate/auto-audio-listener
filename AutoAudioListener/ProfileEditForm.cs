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
                FormClosing -= ProfileEditForm_FormClosing;
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
            var result = MessageBox.Show("Save changes?", "Edit Profile", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (result){
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
    }
}
