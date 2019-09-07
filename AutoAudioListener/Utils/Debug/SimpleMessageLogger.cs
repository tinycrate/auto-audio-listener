using System;
using System.ComponentModel;

namespace AutoAudioListener.Utils.Debug {
    public class SimpleMessageLogger {
        public SimpleMessageLogger(string timestampFormat) {
            Messages = new BindingList<string>();
            TimestampFormat = timestampFormat;
        }

        public SimpleMessageLogger() : this("hh:mm:ss") { }

        public BindingList<string> Messages { get; set; }
        public string TimestampFormat { get; set; }

        public virtual void Add(string message) {
            Messages.Add($"[{DateTime.Now.ToString(TimestampFormat)}]: {message}");
        }

        public virtual void Clear() {
            Messages.Clear();
        }
    }
}