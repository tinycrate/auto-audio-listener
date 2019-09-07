using System;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace AutoAudioListener.Controls {
    public partial class VolumeSensitivityControl : UserControl {
        public VolumeSensitivityControl() {
            InitializeComponent();
        }

        public float MaxZoomFactor { get; set; } = 1f;

        public float Value { get; private set; } = 0.002f;
        public float LowerRange { get; private set; } = 0.0005f;
        public float UpperRange { get; private set; } = 0.005f;
        public bool ManualUpdated { get; private set; } = true;

        public MMDevice MonitoringDevice { get; private set; }
        public event EventHandler ValueChanged;

        public void SetValue(float value) {
            if (value >= 0.00001f) {
                Value = value;
                UpperRange = Math.Min(1, Value * (1 + MaxZoomFactor));
                LowerRange = Math.Max(0, Value * (1 - MaxZoomFactor));
                ManualUpdated = true;
                UpdateTrackPosition();
            }
        }

        public void SetMonitoringDevice(MMDevice device) {
            MonitoringDevice = device;
            updateTimer.Enabled = true;
        }

        public void StopMonitoring() {
            updateTimer.Enabled = false;
        }

        private void UpdateTrackPosition() {
            double position = (Value - LowerRange) / (UpperRange - LowerRange);
            sensitivityTrackBar.Value =
                (int) Math.Round(Math.Min(Math.Max(position, 0), 1) * sensitivityTrackBar.Maximum);
        }

        private void sensitivityTrackBar_ValueChanged(object sender, EventArgs e) {
            if (!ManualUpdated) {
                Value = (float) sensitivityTrackBar.Value / sensitivityTrackBar.Maximum * (UpperRange - LowerRange) +
                        LowerRange;
                ValueChanged?.Invoke(this, EventArgs.Empty);
            } else {
                ManualUpdated = false;
            }
            sensitivityBar.Threshold = (int) Math.Round(
                (float) sensitivityTrackBar.Value / sensitivityTrackBar.Maximum * sensitivityBar.Maximum
            );
        }

        private void updateTimer_Tick(object sender, EventArgs e) {
            double position = (Math.Min(1, MonitoringDevice.AudioMeterInformation.MasterPeakValue) - LowerRange) /
                              (UpperRange - LowerRange);
            sensitivityBar.Value = (int) Math.Round(Math.Min(Math.Max(position, 0), 1) * sensitivityBar.Maximum);
        }
    }
}