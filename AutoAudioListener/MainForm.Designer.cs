namespace AutoAudioListener {
    partial class MainForm {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.inputDeviceGroupBox = new System.Windows.Forms.GroupBox();
            this.inputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.outputDevicesGroupBox = new System.Windows.Forms.GroupBox();
            this.outputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.volumeMeterGroupBox = new System.Windows.Forms.GroupBox();
            this.volumeBarTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftVolumeBarLabel = new System.Windows.Forms.Label();
            this.leftVolumeBar = new AutoAudioListener.Controls.VolumeMeterBar();
            this.rightVolumeBarLabel = new System.Windows.Forms.Label();
            this.rightVolumeBar = new AutoAudioListener.Controls.VolumeMeterBar();
            this.profileComboBox = new System.Windows.Forms.ComboBox();
            this.profileGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteProfileButton = new System.Windows.Forms.Button();
            this.addProfileButton = new System.Windows.Forms.Button();
            this.editProfileButton = new System.Windows.Forms.Button();
            this.controlsGroupBox = new System.Windows.Forms.GroupBox();
            this.viewLogsButton = new System.Windows.Forms.Button();
            this.startStopListeningButton = new System.Windows.Forms.Button();
            this.runAtStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.trayMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.inputDeviceGroupBox.SuspendLayout();
            this.outputDevicesGroupBox.SuspendLayout();
            this.volumeMeterGroupBox.SuspendLayout();
            this.volumeBarTableLayoutPanel.SuspendLayout();
            this.profileGroupBox.SuspendLayout();
            this.controlsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Text = "Auto Audio Listener";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(95, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 318);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(222, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(46, 17);
            this.statusLabel.Text = "Ready.";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // inputDeviceGroupBox
            // 
            this.inputDeviceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDeviceGroupBox.Controls.Add(this.inputDeviceComboBox);
            this.inputDeviceGroupBox.Location = new System.Drawing.Point(12, 12);
            this.inputDeviceGroupBox.Name = "inputDeviceGroupBox";
            this.inputDeviceGroupBox.Size = new System.Drawing.Size(196, 49);
            this.inputDeviceGroupBox.TabIndex = 5;
            this.inputDeviceGroupBox.TabStop = false;
            this.inputDeviceGroupBox.Text = "1. Input Device";
            // 
            // inputDeviceComboBox
            // 
            this.inputDeviceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputDeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputDeviceComboBox.FormattingEnabled = true;
            this.inputDeviceComboBox.Location = new System.Drawing.Point(6, 18);
            this.inputDeviceComboBox.Name = "inputDeviceComboBox";
            this.inputDeviceComboBox.Size = new System.Drawing.Size(184, 20);
            this.inputDeviceComboBox.TabIndex = 0;
            // 
            // outputDevicesGroupBox
            // 
            this.outputDevicesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDevicesGroupBox.Controls.Add(this.outputDeviceComboBox);
            this.outputDevicesGroupBox.Location = new System.Drawing.Point(12, 67);
            this.outputDevicesGroupBox.Name = "outputDevicesGroupBox";
            this.outputDevicesGroupBox.Size = new System.Drawing.Size(196, 49);
            this.outputDevicesGroupBox.TabIndex = 6;
            this.outputDevicesGroupBox.TabStop = false;
            this.outputDevicesGroupBox.Text = "2. Output Device";
            // 
            // outputDeviceComboBox
            // 
            this.outputDeviceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputDeviceComboBox.FormattingEnabled = true;
            this.outputDeviceComboBox.Location = new System.Drawing.Point(6, 18);
            this.outputDeviceComboBox.Name = "outputDeviceComboBox";
            this.outputDeviceComboBox.Size = new System.Drawing.Size(184, 20);
            this.outputDeviceComboBox.TabIndex = 0;
            // 
            // volumeMeterGroupBox
            // 
            this.volumeMeterGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.volumeMeterGroupBox.Controls.Add(this.volumeBarTableLayoutPanel);
            this.volumeMeterGroupBox.Location = new System.Drawing.Point(12, 122);
            this.volumeMeterGroupBox.Name = "volumeMeterGroupBox";
            this.volumeMeterGroupBox.Size = new System.Drawing.Size(90, 193);
            this.volumeMeterGroupBox.TabIndex = 1;
            this.volumeMeterGroupBox.TabStop = false;
            this.volumeMeterGroupBox.Text = "Volume Meter";
            // 
            // volumeBarTableLayoutPanel
            // 
            this.volumeBarTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeBarTableLayoutPanel.ColumnCount = 2;
            this.volumeBarTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.volumeBarTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.volumeBarTableLayoutPanel.Controls.Add(this.leftVolumeBarLabel, 0, 1);
            this.volumeBarTableLayoutPanel.Controls.Add(this.leftVolumeBar, 0, 0);
            this.volumeBarTableLayoutPanel.Controls.Add(this.rightVolumeBarLabel, 1, 1);
            this.volumeBarTableLayoutPanel.Controls.Add(this.rightVolumeBar, 1, 0);
            this.volumeBarTableLayoutPanel.Location = new System.Drawing.Point(6, 17);
            this.volumeBarTableLayoutPanel.Name = "volumeBarTableLayoutPanel";
            this.volumeBarTableLayoutPanel.RowCount = 2;
            this.volumeBarTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.20988F));
            this.volumeBarTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.790123F));
            this.volumeBarTableLayoutPanel.Size = new System.Drawing.Size(76, 170);
            this.volumeBarTableLayoutPanel.TabIndex = 7;
            // 
            // leftVolumeBarLabel
            // 
            this.leftVolumeBarLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leftVolumeBarLabel.Location = new System.Drawing.Point(3, 158);
            this.leftVolumeBarLabel.Name = "leftVolumeBarLabel";
            this.leftVolumeBarLabel.Size = new System.Drawing.Size(32, 12);
            this.leftVolumeBarLabel.TabIndex = 2;
            this.leftVolumeBarLabel.Text = "L";
            this.leftVolumeBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftVolumeBar
            // 
            this.leftVolumeBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leftVolumeBar.FillStyle = AutoAudioListener.Controls.VolumeMeterBar.VolumeMeterFillStyle.Vertical;
            this.leftVolumeBar.Location = new System.Drawing.Point(3, 3);
            this.leftVolumeBar.Maximum = 1000;
            this.leftVolumeBar.Name = "leftVolumeBar";
            this.leftVolumeBar.Size = new System.Drawing.Size(32, 152);
            this.leftVolumeBar.TabIndex = 0;
            // 
            // rightVolumeBarLabel
            // 
            this.rightVolumeBarLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightVolumeBarLabel.Location = new System.Drawing.Point(41, 158);
            this.rightVolumeBarLabel.Name = "rightVolumeBarLabel";
            this.rightVolumeBarLabel.Size = new System.Drawing.Size(32, 12);
            this.rightVolumeBarLabel.TabIndex = 3;
            this.rightVolumeBarLabel.Text = "R";
            this.rightVolumeBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightVolumeBar
            // 
            this.rightVolumeBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightVolumeBar.FillStyle = AutoAudioListener.Controls.VolumeMeterBar.VolumeMeterFillStyle.Vertical;
            this.rightVolumeBar.Location = new System.Drawing.Point(41, 3);
            this.rightVolumeBar.Maximum = 1000;
            this.rightVolumeBar.Name = "rightVolumeBar";
            this.rightVolumeBar.Size = new System.Drawing.Size(32, 152);
            this.rightVolumeBar.TabIndex = 1;
            // 
            // profileComboBox
            // 
            this.profileComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profileComboBox.FormattingEnabled = true;
            this.profileComboBox.Location = new System.Drawing.Point(6, 21);
            this.profileComboBox.Name = "profileComboBox";
            this.profileComboBox.Size = new System.Drawing.Size(88, 20);
            this.profileComboBox.TabIndex = 0;
            this.profileComboBox.SelectionChangeCommitted += new System.EventHandler(this.profileComboBox_SelectionChangeCommitted);
            // 
            // profileGroupBox
            // 
            this.profileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profileGroupBox.Controls.Add(this.deleteProfileButton);
            this.profileGroupBox.Controls.Add(this.addProfileButton);
            this.profileGroupBox.Controls.Add(this.editProfileButton);
            this.profileGroupBox.Controls.Add(this.profileComboBox);
            this.profileGroupBox.Location = new System.Drawing.Point(108, 122);
            this.profileGroupBox.Name = "profileGroupBox";
            this.profileGroupBox.Size = new System.Drawing.Size(100, 81);
            this.profileGroupBox.TabIndex = 7;
            this.profileGroupBox.TabStop = false;
            this.profileGroupBox.Text = "3. Profile";
            // 
            // deleteProfileButton
            // 
            this.deleteProfileButton.Location = new System.Drawing.Point(75, 47);
            this.deleteProfileButton.Name = "deleteProfileButton";
            this.deleteProfileButton.Size = new System.Drawing.Size(20, 23);
            this.deleteProfileButton.TabIndex = 3;
            this.deleteProfileButton.Text = "-";
            this.deleteProfileButton.UseVisualStyleBackColor = true;
            this.deleteProfileButton.Click += new System.EventHandler(this.deleteProfileButton_Click);
            // 
            // addProfileButton
            // 
            this.addProfileButton.Location = new System.Drawing.Point(6, 47);
            this.addProfileButton.Name = "addProfileButton";
            this.addProfileButton.Size = new System.Drawing.Size(20, 23);
            this.addProfileButton.TabIndex = 2;
            this.addProfileButton.Text = "+";
            this.addProfileButton.UseVisualStyleBackColor = true;
            this.addProfileButton.Click += new System.EventHandler(this.addProfileButton_Click);
            // 
            // editProfileButton
            // 
            this.editProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editProfileButton.Location = new System.Drawing.Point(25, 47);
            this.editProfileButton.Name = "editProfileButton";
            this.editProfileButton.Size = new System.Drawing.Size(51, 23);
            this.editProfileButton.TabIndex = 1;
            this.editProfileButton.Text = "Edit";
            this.editProfileButton.UseVisualStyleBackColor = true;
            this.editProfileButton.Click += new System.EventHandler(this.editProfileButton_Click);
            // 
            // controlsGroupBox
            // 
            this.controlsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlsGroupBox.Controls.Add(this.viewLogsButton);
            this.controlsGroupBox.Controls.Add(this.startStopListeningButton);
            this.controlsGroupBox.Location = new System.Drawing.Point(108, 209);
            this.controlsGroupBox.Name = "controlsGroupBox";
            this.controlsGroupBox.Size = new System.Drawing.Size(100, 85);
            this.controlsGroupBox.TabIndex = 8;
            this.controlsGroupBox.TabStop = false;
            this.controlsGroupBox.Text = "4. Controls";
            // 
            // viewLogsButton
            // 
            this.viewLogsButton.Location = new System.Drawing.Point(6, 50);
            this.viewLogsButton.Name = "viewLogsButton";
            this.viewLogsButton.Size = new System.Drawing.Size(88, 23);
            this.viewLogsButton.TabIndex = 1;
            this.viewLogsButton.Text = "View Logs";
            this.viewLogsButton.UseVisualStyleBackColor = true;
            this.viewLogsButton.Click += new System.EventHandler(this.viewLogsButton_Click);
            // 
            // startStopListeningButton
            // 
            this.startStopListeningButton.Location = new System.Drawing.Point(6, 21);
            this.startStopListeningButton.Name = "startStopListeningButton";
            this.startStopListeningButton.Size = new System.Drawing.Size(88, 23);
            this.startStopListeningButton.TabIndex = 0;
            this.startStopListeningButton.Text = "Start Listening";
            this.startStopListeningButton.UseVisualStyleBackColor = true;
            this.startStopListeningButton.Click += new System.EventHandler(this.startStopListeningButton_Click);
            // 
            // runAtStartupCheckBox
            // 
            this.runAtStartupCheckBox.AutoSize = true;
            this.runAtStartupCheckBox.Location = new System.Drawing.Point(114, 296);
            this.runAtStartupCheckBox.Name = "runAtStartupCheckBox";
            this.runAtStartupCheckBox.Size = new System.Drawing.Size(89, 16);
            this.runAtStartupCheckBox.TabIndex = 10;
            this.runAtStartupCheckBox.Text = "Run at startup";
            this.runAtStartupCheckBox.UseVisualStyleBackColor = true;
            this.runAtStartupCheckBox.CheckedChanged += new System.EventHandler(this.runAtStartupCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 340);
            this.Controls.Add(this.runAtStartupCheckBox);
            this.Controls.Add(this.controlsGroupBox);
            this.Controls.Add(this.profileGroupBox);
            this.Controls.Add(this.volumeMeterGroupBox);
            this.Controls.Add(this.outputDevicesGroupBox);
            this.Controls.Add(this.inputDeviceGroupBox);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Listener";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.trayMenu.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.inputDeviceGroupBox.ResumeLayout(false);
            this.outputDevicesGroupBox.ResumeLayout(false);
            this.volumeMeterGroupBox.ResumeLayout(false);
            this.volumeBarTableLayoutPanel.ResumeLayout(false);
            this.profileGroupBox.ResumeLayout(false);
            this.controlsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox inputDeviceGroupBox;
        private System.Windows.Forms.ComboBox inputDeviceComboBox;
        private System.Windows.Forms.GroupBox outputDevicesGroupBox;
        private System.Windows.Forms.ComboBox outputDeviceComboBox;
        private System.Windows.Forms.GroupBox volumeMeterGroupBox;
        private System.Windows.Forms.TableLayoutPanel volumeBarTableLayoutPanel;
        private System.Windows.Forms.Label leftVolumeBarLabel;
        private Controls.VolumeMeterBar leftVolumeBar;
        private System.Windows.Forms.Label rightVolumeBarLabel;
        private Controls.VolumeMeterBar rightVolumeBar;
        private System.Windows.Forms.ComboBox profileComboBox;
        private System.Windows.Forms.GroupBox profileGroupBox;
        private System.Windows.Forms.Button addProfileButton;
        private System.Windows.Forms.Button editProfileButton;
        private System.Windows.Forms.GroupBox controlsGroupBox;
        private System.Windows.Forms.Button startStopListeningButton;
        private System.Windows.Forms.Button viewLogsButton;
        private System.Windows.Forms.CheckBox runAtStartupCheckBox;
        private System.Windows.Forms.Button deleteProfileButton;
    }
}

