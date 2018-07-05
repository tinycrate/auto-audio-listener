using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAudioListener.Audio {
    public class ActiveAudioListenerFormat : AudioListenerFormat {

        public ActiveAudioListenerFormat(AudioListenerFormat format, float slienceLevel, float activeLevel, double activeTimeoutMilliseconds) : base(format) {
            this.SlienceLevel = slienceLevel;
            this.ActiveLevel = activeLevel;
            this.ActiveTimeoutMilliseconds = activeTimeoutMilliseconds;
        }

        private ActiveAudioListenerFormat() {
        }

        public static new ActiveAudioListenerFormat Default {
            get {
                return new ActiveAudioListenerFormat(AudioListenerFormat.Default, 0.0015f, 0.0020f, 2000);
            }
        }

        public float SlienceLevel { get; set; }
        public float ActiveLevel { get; set; }
        public double ActiveTimeoutMilliseconds { get; set; }
    }
}
