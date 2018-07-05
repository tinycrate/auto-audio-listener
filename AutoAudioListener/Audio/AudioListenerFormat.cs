using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;

namespace AutoAudioListener.Audio {
    public class AudioListenerFormat {

        public AudioListenerFormat(string inputDeviceID, string outputDeviceID, int preferredInputLatency, int preferredOutputLatency) {
            this.inputDeviceID = inputDeviceID;
            this.outputDeviceID = outputDeviceID;
            this.preferredInputLatency = preferredInputLatency;
            this.preferredOutputLatency = preferredOutputLatency;
        }

        public AudioListenerFormat(string inputDeviceID, string outputDeviceID, int preferredInputLatency)
            : this(inputDeviceID, outputDeviceID, preferredInputLatency, 1) { }

        public AudioListenerFormat(string inputDeviceID, string outputDeviceID)
            : this(inputDeviceID, outputDeviceID, 100, 200) { }

        public AudioListenerFormat(AudioListenerFormat audioListenerFormat) 
            : this(audioListenerFormat.inputDeviceID, audioListenerFormat.outputDeviceID, audioListenerFormat.preferredInputLatency, audioListenerFormat.preferredOutputLatency) { }

        protected AudioListenerFormat() {
        }

        public static AudioListenerFormat Default {
            get{
                using (var devices = new MMDeviceEnumerator()) {
                    return new AudioListenerFormat(
                        devices.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia).ID,
                        devices.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia).ID);
                }    
            }
        }

        public string inputDeviceID { get; set; }
        public string outputDeviceID { get; set; }
        public int preferredInputLatency { get; set; }
        public int preferredOutputLatency { get; set; }
    }
}
