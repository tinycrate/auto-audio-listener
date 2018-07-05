using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAudioListener.Utils.Debug {
    public class SimpleMessageLogger {

        public SimpleMessageLogger() {
            Messages = new BindingList<string>();
        }

        public BindingList<string> Messages { get; set; }

        public virtual void Add(string message) {
            Messages.Add(message);
        }

        public virtual void Clear() {
            Messages.Clear();
        }
    }
}
