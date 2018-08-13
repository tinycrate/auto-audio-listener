namespace AutoAudioListener.Controls {
    partial class VolumeSensitivityControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.sensitivityTrackBar = new System.Windows.Forms.TrackBar();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.sensitivityBar = new AutoAudioListener.Controls.VolumeSensitivityBar();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivityTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // sensitivityTrackBar
            // 
            this.sensitivityTrackBar.AutoSize = false;
            this.sensitivityTrackBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sensitivityTrackBar.Location = new System.Drawing.Point(0, 22);
            this.sensitivityTrackBar.Maximum = 1000;
            this.sensitivityTrackBar.MaximumSize = new System.Drawing.Size(0, 25);
            this.sensitivityTrackBar.Name = "sensitivityTrackBar";
            this.sensitivityTrackBar.Size = new System.Drawing.Size(151, 25);
            this.sensitivityTrackBar.TabIndex = 0;
            this.sensitivityTrackBar.TickFrequency = 100;
            this.sensitivityTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.sensitivityTrackBar.Value = 500;
            this.sensitivityTrackBar.ValueChanged += new System.EventHandler(this.sensitivityTrackBar_ValueChanged);
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // sensitivityBar
            // 
            this.sensitivityBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.sensitivityBar.Location = new System.Drawing.Point(0, 0);
            this.sensitivityBar.Maximum = 1000;
            this.sensitivityBar.Name = "sensitivityBar";
            this.sensitivityBar.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(176)))), ((int)(((byte)(37)))));
            this.sensitivityBar.NormalIndicatorColor = System.Drawing.Color.RoyalBlue;
            this.sensitivityBar.Size = new System.Drawing.Size(151, 23);
            this.sensitivityBar.TabIndex = 1;
            this.sensitivityBar.Threshold = 500;
            this.sensitivityBar.TriggeredColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(191)))), ((int)(((byte)(68)))));
            this.sensitivityBar.TriggeredIndicatorColor = System.Drawing.Color.GreenYellow;
            // 
            // VolumeSensitivityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sensitivityBar);
            this.Controls.Add(this.sensitivityTrackBar);
            this.Name = "VolumeSensitivityControl";
            this.Size = new System.Drawing.Size(151, 47);
            ((System.ComponentModel.ISupportInitialize)(this.sensitivityTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar sensitivityTrackBar;
        private VolumeSensitivityBar sensitivityBar;
        private System.Windows.Forms.Timer updateTimer;
    }
}
