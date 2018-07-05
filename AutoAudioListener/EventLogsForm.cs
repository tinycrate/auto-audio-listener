using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAudioListener {
    public partial class EventLogsForm : Form {

        public EventLogsForm(IBindingList logs) {
            InitializeComponent();
            eventLogListBox.DataSource = logs;
        }

        private void EventLogsForm_Load(object sender, EventArgs e) {
            if (eventLogListBox.Items.Count > 0) {
                eventLogListBox.SelectedIndex = eventLogListBox.Items.Count - 1;
            }
        }
    }
}
