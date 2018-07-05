namespace AutoAudioListener {
    partial class EventLogsForm {
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
            this.eventLogListBox = new AutoAudioListener.Controls.ScrollingListBox();
            this.SuspendLayout();
            // 
            // eventLogListBox
            // 
            this.eventLogListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventLogListBox.EnableAutomaticScrolling = true;
            this.eventLogListBox.FormattingEnabled = true;
            this.eventLogListBox.HighlightChangedItem = true;
            this.eventLogListBox.ItemHeight = 12;
            this.eventLogListBox.Location = new System.Drawing.Point(0, 0);
            this.eventLogListBox.Name = "eventLogListBox";
            this.eventLogListBox.Size = new System.Drawing.Size(397, 232);
            this.eventLogListBox.TabIndex = 0;
            // 
            // EventLogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(397, 232);
            this.Controls.Add(this.eventLogListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "EventLogsForm";
            this.Text = "Event Logs";
            this.Load += new System.EventHandler(this.EventLogsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ScrollingListBox eventLogListBox;
    }
}