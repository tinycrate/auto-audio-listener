namespace AutoAudioListener {
    partial class ProfileEditForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.saveButton = new System.Windows.Forms.Button();
            this.noiseFloorSensitivityControl = new AutoAudioListener.Controls.VolumeSensitivityControl();
            this.noiseFloorDescriptionLabel = new System.Windows.Forms.Label();
            this.noiseFloorValueBox = new System.Windows.Forms.NumericUpDown();
            this.noiseFloorAutoDetectButton = new System.Windows.Forms.Button();
            this.noiseFloorGroupBox = new System.Windows.Forms.GroupBox();
            this.activeLevelSensitivityControl = new AutoAudioListener.Controls.VolumeSensitivityControl();
            this.activeLevelDescriptionLabel = new System.Windows.Forms.Label();
            this.activeLevelValueBox = new System.Windows.Forms.NumericUpDown();
            this.activeLevelAutoDetectButton = new System.Windows.Forms.Button();
            this.activeLevelGroupBox = new System.Windows.Forms.GroupBox();
            this.inputLatencyLabel = new System.Windows.Forms.Label();
            this.inputLatencyValueBox = new System.Windows.Forms.NumericUpDown();
            this.outputLatencyLabel = new System.Windows.Forms.Label();
            this.outputLatencyValueBox = new System.Windows.Forms.NumericUpDown();
            this.latencyDescriptionLabel = new System.Windows.Forms.Label();
            this.latencyGroupBox = new System.Windows.Forms.GroupBox();
            this.timeoutDescriptionLabel = new System.Windows.Forms.Label();
            this.timeoutLabel = new System.Windows.Forms.Label();
            this.timeoutValueBox = new System.Windows.Forms.NumericUpDown();
            this.timeoutGroupBox = new System.Windows.Forms.GroupBox();
            this.prirorityDescriptionLabel = new System.Windows.Forms.Label();
            this.prirorityLabel = new System.Windows.Forms.Label();
            this.prirorityComboBox = new System.Windows.Forms.ComboBox();
            this.prirorityGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.noiseFloorValueBox)).BeginInit();
            this.noiseFloorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activeLevelValueBox)).BeginInit();
            this.activeLevelGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputLatencyValueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputLatencyValueBox)).BeginInit();
            this.latencyGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutValueBox)).BeginInit();
            this.timeoutGroupBox.SuspendLayout();
            this.prirorityGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.saveButton.Location = new System.Drawing.Point(152, 490);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // noiseFloorSensitivityControl
            // 
            this.noiseFloorSensitivityControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.noiseFloorSensitivityControl.Location = new System.Drawing.Point(8, 40);
            this.noiseFloorSensitivityControl.Name = "noiseFloorSensitivityControl";
            this.noiseFloorSensitivityControl.Size = new System.Drawing.Size(246, 47);
            this.noiseFloorSensitivityControl.TabIndex = 0;
            // 
            // noiseFloorDescriptionLabel
            // 
            this.noiseFloorDescriptionLabel.AutoSize = true;
            this.noiseFloorDescriptionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.noiseFloorDescriptionLabel.Location = new System.Drawing.Point(6, 18);
            this.noiseFloorDescriptionLabel.Name = "noiseFloorDescriptionLabel";
            this.noiseFloorDescriptionLabel.Size = new System.Drawing.Size(314, 12);
            this.noiseFloorDescriptionLabel.TabIndex = 1;
            this.noiseFloorDescriptionLabel.Text = "Volume level below this value will be considered complete slience.";
            // 
            // noiseFloorValueBox
            // 
            this.noiseFloorValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.noiseFloorValueBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.noiseFloorValueBox.Location = new System.Drawing.Point(260, 65);
            this.noiseFloorValueBox.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.noiseFloorValueBox.Name = "noiseFloorValueBox";
            this.noiseFloorValueBox.Size = new System.Drawing.Size(77, 22);
            this.noiseFloorValueBox.TabIndex = 0;
            this.noiseFloorValueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // noiseFloorAutoDetectButton
            // 
            this.noiseFloorAutoDetectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.noiseFloorAutoDetectButton.Location = new System.Drawing.Point(260, 40);
            this.noiseFloorAutoDetectButton.Name = "noiseFloorAutoDetectButton";
            this.noiseFloorAutoDetectButton.Size = new System.Drawing.Size(77, 23);
            this.noiseFloorAutoDetectButton.TabIndex = 2;
            this.noiseFloorAutoDetectButton.Text = "Auto Detect";
            this.noiseFloorAutoDetectButton.UseVisualStyleBackColor = true;
            // 
            // noiseFloorGroupBox
            // 
            this.noiseFloorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noiseFloorGroupBox.Controls.Add(this.noiseFloorAutoDetectButton);
            this.noiseFloorGroupBox.Controls.Add(this.noiseFloorValueBox);
            this.noiseFloorGroupBox.Controls.Add(this.noiseFloorDescriptionLabel);
            this.noiseFloorGroupBox.Controls.Add(this.noiseFloorSensitivityControl);
            this.noiseFloorGroupBox.Location = new System.Drawing.Point(12, 12);
            this.noiseFloorGroupBox.Name = "noiseFloorGroupBox";
            this.noiseFloorGroupBox.Size = new System.Drawing.Size(343, 102);
            this.noiseFloorGroupBox.TabIndex = 1;
            this.noiseFloorGroupBox.TabStop = false;
            this.noiseFloorGroupBox.Text = "Noise Floor Level";
            // 
            // activeLevelSensitivityControl
            // 
            this.activeLevelSensitivityControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.activeLevelSensitivityControl.Location = new System.Drawing.Point(8, 40);
            this.activeLevelSensitivityControl.Name = "activeLevelSensitivityControl";
            this.activeLevelSensitivityControl.Size = new System.Drawing.Size(246, 47);
            this.activeLevelSensitivityControl.TabIndex = 0;
            // 
            // activeLevelDescriptionLabel
            // 
            this.activeLevelDescriptionLabel.AutoSize = true;
            this.activeLevelDescriptionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.activeLevelDescriptionLabel.Location = new System.Drawing.Point(6, 18);
            this.activeLevelDescriptionLabel.Name = "activeLevelDescriptionLabel";
            this.activeLevelDescriptionLabel.Size = new System.Drawing.Size(216, 12);
            this.activeLevelDescriptionLabel.TabIndex = 1;
            this.activeLevelDescriptionLabel.Text = "Volume level above this will trigger listening.";
            // 
            // activeLevelValueBox
            // 
            this.activeLevelValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.activeLevelValueBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.activeLevelValueBox.Location = new System.Drawing.Point(260, 65);
            this.activeLevelValueBox.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.activeLevelValueBox.Name = "activeLevelValueBox";
            this.activeLevelValueBox.Size = new System.Drawing.Size(77, 22);
            this.activeLevelValueBox.TabIndex = 0;
            this.activeLevelValueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // activeLevelAutoDetectButton
            // 
            this.activeLevelAutoDetectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.activeLevelAutoDetectButton.Location = new System.Drawing.Point(260, 40);
            this.activeLevelAutoDetectButton.Name = "activeLevelAutoDetectButton";
            this.activeLevelAutoDetectButton.Size = new System.Drawing.Size(77, 23);
            this.activeLevelAutoDetectButton.TabIndex = 2;
            this.activeLevelAutoDetectButton.Text = "Auto Detect";
            this.activeLevelAutoDetectButton.UseVisualStyleBackColor = true;
            // 
            // activeLevelGroupBox
            // 
            this.activeLevelGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.activeLevelGroupBox.Controls.Add(this.activeLevelAutoDetectButton);
            this.activeLevelGroupBox.Controls.Add(this.activeLevelValueBox);
            this.activeLevelGroupBox.Controls.Add(this.activeLevelDescriptionLabel);
            this.activeLevelGroupBox.Controls.Add(this.activeLevelSensitivityControl);
            this.activeLevelGroupBox.Location = new System.Drawing.Point(12, 120);
            this.activeLevelGroupBox.Name = "activeLevelGroupBox";
            this.activeLevelGroupBox.Size = new System.Drawing.Size(343, 102);
            this.activeLevelGroupBox.TabIndex = 3;
            this.activeLevelGroupBox.TabStop = false;
            this.activeLevelGroupBox.Text = "Active Level";
            // 
            // inputLatencyLabel
            // 
            this.inputLatencyLabel.AutoSize = true;
            this.inputLatencyLabel.Location = new System.Drawing.Point(6, 41);
            this.inputLatencyLabel.Name = "inputLatencyLabel";
            this.inputLatencyLabel.Size = new System.Drawing.Size(97, 12);
            this.inputLatencyLabel.TabIndex = 0;
            this.inputLatencyLabel.Text = "Input Latency (ms):";
            // 
            // inputLatencyValueBox
            // 
            this.inputLatencyValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputLatencyValueBox.Location = new System.Drawing.Point(118, 39);
            this.inputLatencyValueBox.Name = "inputLatencyValueBox";
            this.inputLatencyValueBox.Size = new System.Drawing.Size(78, 22);
            this.inputLatencyValueBox.TabIndex = 1;
            // 
            // outputLatencyLabel
            // 
            this.outputLatencyLabel.AutoSize = true;
            this.outputLatencyLabel.Location = new System.Drawing.Point(6, 65);
            this.outputLatencyLabel.Name = "outputLatencyLabel";
            this.outputLatencyLabel.Size = new System.Drawing.Size(104, 12);
            this.outputLatencyLabel.TabIndex = 2;
            this.outputLatencyLabel.Text = "Output Latency (ms):";
            // 
            // outputLatencyValueBox
            // 
            this.outputLatencyValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputLatencyValueBox.Location = new System.Drawing.Point(118, 63);
            this.outputLatencyValueBox.Name = "outputLatencyValueBox";
            this.outputLatencyValueBox.Size = new System.Drawing.Size(78, 22);
            this.outputLatencyValueBox.TabIndex = 3;
            // 
            // latencyDescriptionLabel
            // 
            this.latencyDescriptionLabel.AutoSize = true;
            this.latencyDescriptionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.latencyDescriptionLabel.Location = new System.Drawing.Point(6, 18);
            this.latencyDescriptionLabel.Name = "latencyDescriptionLabel";
            this.latencyDescriptionLabel.Size = new System.Drawing.Size(322, 12);
            this.latencyDescriptionLabel.TabIndex = 4;
            this.latencyDescriptionLabel.Text = "Lower values require higher processing power and process prirority.";
            // 
            // latencyGroupBox
            // 
            this.latencyGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.latencyGroupBox.Controls.Add(this.latencyDescriptionLabel);
            this.latencyGroupBox.Controls.Add(this.outputLatencyValueBox);
            this.latencyGroupBox.Controls.Add(this.outputLatencyLabel);
            this.latencyGroupBox.Controls.Add(this.inputLatencyValueBox);
            this.latencyGroupBox.Controls.Add(this.inputLatencyLabel);
            this.latencyGroupBox.Location = new System.Drawing.Point(12, 228);
            this.latencyGroupBox.Name = "latencyGroupBox";
            this.latencyGroupBox.Size = new System.Drawing.Size(343, 96);
            this.latencyGroupBox.TabIndex = 4;
            this.latencyGroupBox.TabStop = false;
            this.latencyGroupBox.Text = "Latency";
            // 
            // timeoutDescriptionLabel
            // 
            this.timeoutDescriptionLabel.AutoSize = true;
            this.timeoutDescriptionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.timeoutDescriptionLabel.Location = new System.Drawing.Point(8, 18);
            this.timeoutDescriptionLabel.Name = "timeoutDescriptionLabel";
            this.timeoutDescriptionLabel.Size = new System.Drawing.Size(304, 12);
            this.timeoutDescriptionLabel.TabIndex = 5;
            this.timeoutDescriptionLabel.Text = "Number of miliseconds before audio becomes deactivated again.\r\n";
            // 
            // timeoutLabel
            // 
            this.timeoutLabel.AutoSize = true;
            this.timeoutLabel.Location = new System.Drawing.Point(8, 41);
            this.timeoutLabel.Name = "timeoutLabel";
            this.timeoutLabel.Size = new System.Drawing.Size(104, 12);
            this.timeoutLabel.TabIndex = 5;
            this.timeoutLabel.Text = "Active Timeout (ms):";
            // 
            // timeoutValueBox
            // 
            this.timeoutValueBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeoutValueBox.Location = new System.Drawing.Point(118, 39);
            this.timeoutValueBox.Name = "timeoutValueBox";
            this.timeoutValueBox.Size = new System.Drawing.Size(78, 22);
            this.timeoutValueBox.TabIndex = 6;
            // 
            // timeoutGroupBox
            // 
            this.timeoutGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeoutGroupBox.Controls.Add(this.timeoutValueBox);
            this.timeoutGroupBox.Controls.Add(this.timeoutLabel);
            this.timeoutGroupBox.Controls.Add(this.timeoutDescriptionLabel);
            this.timeoutGroupBox.Location = new System.Drawing.Point(12, 330);
            this.timeoutGroupBox.Name = "timeoutGroupBox";
            this.timeoutGroupBox.Size = new System.Drawing.Size(343, 74);
            this.timeoutGroupBox.TabIndex = 5;
            this.timeoutGroupBox.TabStop = false;
            this.timeoutGroupBox.Text = "Active Timeout";
            // 
            // prirorityDescriptionLabel
            // 
            this.prirorityDescriptionLabel.AutoSize = true;
            this.prirorityDescriptionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.prirorityDescriptionLabel.Location = new System.Drawing.Point(8, 18);
            this.prirorityDescriptionLabel.Name = "prirorityDescriptionLabel";
            this.prirorityDescriptionLabel.Size = new System.Drawing.Size(291, 12);
            this.prirorityDescriptionLabel.TabIndex = 5;
            this.prirorityDescriptionLabel.Text = "Higher settings reduce shuttering under sudden CPU demand.";
            // 
            // prirorityLabel
            // 
            this.prirorityLabel.AutoSize = true;
            this.prirorityLabel.Location = new System.Drawing.Point(8, 41);
            this.prirorityLabel.Name = "prirorityLabel";
            this.prirorityLabel.Size = new System.Drawing.Size(84, 12);
            this.prirorityLabel.TabIndex = 5;
            this.prirorityLabel.Text = "Process Prirority:";
            // 
            // prirorityComboBox
            // 
            this.prirorityComboBox.FormattingEnabled = true;
            this.prirorityComboBox.Location = new System.Drawing.Point(118, 38);
            this.prirorityComboBox.Name = "prirorityComboBox";
            this.prirorityComboBox.Size = new System.Drawing.Size(181, 20);
            this.prirorityComboBox.TabIndex = 6;
            // 
            // prirorityGroupBox
            // 
            this.prirorityGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prirorityGroupBox.Controls.Add(this.prirorityComboBox);
            this.prirorityGroupBox.Controls.Add(this.prirorityLabel);
            this.prirorityGroupBox.Controls.Add(this.prirorityDescriptionLabel);
            this.prirorityGroupBox.Location = new System.Drawing.Point(12, 410);
            this.prirorityGroupBox.Name = "prirorityGroupBox";
            this.prirorityGroupBox.Size = new System.Drawing.Size(343, 71);
            this.prirorityGroupBox.TabIndex = 7;
            this.prirorityGroupBox.TabStop = false;
            this.prirorityGroupBox.Text = "Process Priority";
            // 
            // profileEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 528);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.prirorityGroupBox);
            this.Controls.Add(this.timeoutGroupBox);
            this.Controls.Add(this.latencyGroupBox);
            this.Controls.Add(this.activeLevelGroupBox);
            this.Controls.Add(this.noiseFloorGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "profileEditForm";
            this.Text = "Edit Profile";
            ((System.ComponentModel.ISupportInitialize)(this.noiseFloorValueBox)).EndInit();
            this.noiseFloorGroupBox.ResumeLayout(false);
            this.noiseFloorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activeLevelValueBox)).EndInit();
            this.activeLevelGroupBox.ResumeLayout(false);
            this.activeLevelGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputLatencyValueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputLatencyValueBox)).EndInit();
            this.latencyGroupBox.ResumeLayout(false);
            this.latencyGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutValueBox)).EndInit();
            this.timeoutGroupBox.ResumeLayout(false);
            this.timeoutGroupBox.PerformLayout();
            this.prirorityGroupBox.ResumeLayout(false);
            this.prirorityGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private Controls.VolumeSensitivityControl noiseFloorSensitivityControl;
        private System.Windows.Forms.Label noiseFloorDescriptionLabel;
        private System.Windows.Forms.NumericUpDown noiseFloorValueBox;
        private System.Windows.Forms.Button noiseFloorAutoDetectButton;
        private System.Windows.Forms.GroupBox noiseFloorGroupBox;
        private Controls.VolumeSensitivityControl activeLevelSensitivityControl;
        private System.Windows.Forms.Label activeLevelDescriptionLabel;
        private System.Windows.Forms.NumericUpDown activeLevelValueBox;
        private System.Windows.Forms.Button activeLevelAutoDetectButton;
        private System.Windows.Forms.GroupBox activeLevelGroupBox;
        private System.Windows.Forms.Label inputLatencyLabel;
        private System.Windows.Forms.NumericUpDown inputLatencyValueBox;
        private System.Windows.Forms.Label outputLatencyLabel;
        private System.Windows.Forms.NumericUpDown outputLatencyValueBox;
        private System.Windows.Forms.Label latencyDescriptionLabel;
        private System.Windows.Forms.GroupBox latencyGroupBox;
        private System.Windows.Forms.Label timeoutDescriptionLabel;
        private System.Windows.Forms.Label timeoutLabel;
        private System.Windows.Forms.NumericUpDown timeoutValueBox;
        private System.Windows.Forms.GroupBox timeoutGroupBox;
        private System.Windows.Forms.Label prirorityDescriptionLabel;
        private System.Windows.Forms.Label prirorityLabel;
        private System.Windows.Forms.ComboBox prirorityComboBox;
        private System.Windows.Forms.GroupBox prirorityGroupBox;
    }
}