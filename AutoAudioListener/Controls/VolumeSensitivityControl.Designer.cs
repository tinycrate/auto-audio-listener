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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.colorableProgressBar1 = new AutoAudioListener.Controls.ColorableProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(0, 22);
            this.trackBar1.Maximum = 100;
            this.trackBar1.MaximumSize = new System.Drawing.Size(0, 25);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(151, 25);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Value = 50;
            // 
            // colorableProgressBar1
            // 
            this.colorableProgressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorableProgressBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(176)))), ((int)(((byte)(37)))));
            this.colorableProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.colorableProgressBar1.Name = "colorableProgressBar1";
            this.colorableProgressBar1.Size = new System.Drawing.Size(151, 23);
            this.colorableProgressBar1.TabIndex = 1;
            // 
            // VolumeSensitivityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorableProgressBar1);
            this.Controls.Add(this.trackBar1);
            this.Name = "VolumeSensitivityControl";
            this.Size = new System.Drawing.Size(151, 47);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private ColorableProgressBar colorableProgressBar1;
    }
}
