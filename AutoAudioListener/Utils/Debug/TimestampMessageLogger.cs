using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAudioListener.Utils.Debug {
    public class TimestampMessageLogger : SimpleMessageLogger {

        public TimestampMessageLogger(string timestampFormat) {
            this.TimestampFormat = timestampFormat;
        }

        public TimestampMessageLogger() : this("hh:mm:ss") { }

        public string TimestampFormat { get; set; }

        public override void Add(string message) {
            Messages.Add($"[{DateTime.Now.ToString(TimestampFormat)}]: {message}.");
        }

    }
}
