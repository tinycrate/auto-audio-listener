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
            this.WorkingProfile = workingProfile;
            BindProfileData();
        }

        CustomProfile WorkingProfile { get; }

        private void BindProfileData() {
            noiseFloorValueBox.DataBindings.Add("Value", WorkingProfile.ActiveListenerFormat, "SlienceLevel", false, DataSourceUpdateMode.OnPropertyChanged);
            activeLevelValueBox.DataBindings.Add("Value", WorkingProfile.ActiveListenerFormat, "ActiveLevel", false, DataSourceUpdateMode.OnPropertyChanged);
            inputLatencyValueBox.DataBindings.Add("Value", WorkingProfile.ActiveListenerFormat, "PreferredInputLatency", false, DataSourceUpdateMode.OnPropertyChanged);
            outputLatencyValueBox.DataBindings.Add("Value", WorkingProfile.ActiveListenerFormat, "PreferredOutputLatency", false, DataSourceUpdateMode.OnPropertyChanged);
            timeoutValueBox.DataBindings.Add("Value", WorkingProfile.ActiveListenerFormat, "ActiveTimeoutMilliseconds", false, DataSourceUpdateMode.OnPropertyChanged);
            priorityComboBox.DataSource = new BindingSource(ProcessPriority, null);
            priorityComboBox.DisplayMember = "Key";
            priorityComboBox.ValueMember = "Value";
            priorityComboBox.SelectedItem = ProcessPriority.First(s => s.Value == WorkingProfile.AppPriority);
        }

        private void saveButton_Click(object sender, EventArgs e) {
            if (WorkingProfile.ValidateData()) {
                WorkingProfile.SaveChanges();
                this.Close();
            } else {
                MessageBox.Show("Some field you've inputted is invalid!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void priorityComboBox_SelectionChangeCommitted(object sender, EventArgs e) {
            WorkingProfile.AppPriority = (ProcessPriorityClass)priorityComboBox.SelectedValue;
        }
    }
}
