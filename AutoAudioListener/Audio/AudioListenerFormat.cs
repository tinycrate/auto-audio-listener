using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;

namespace AutoAudioListener.Audio {
    public class AudioListenerFormat {

        public AudioListenerFormat(string inputDeviceID, string outputDeviceID, int preferredInputLatency, int preferredOutputLatency) {
            this.InputDeviceID = inputDeviceID;
            this.OutputDeviceID = outputDeviceID;
            this.PreferredInputLatency = preferredInputLatency;
            this.PreferredOutputLatency = preferredOutputLatency;
        }

        public AudioListenerFormat(string inputDeviceID, string outputDeviceID, int preferredInputLatency)
            : this(inputDeviceID, outputDeviceID, preferredInputLatency, 1) { }

        public AudioListenerFormat(string inputDeviceID, string outputDeviceID)
            : this(inputDeviceID, outputDeviceID, 100, 200) { }

        public AudioListenerFormat(AudioListenerFormat audioListenerFormat) 
            : this(audioListenerFormat.InputDeviceID, audioListenerFormat.OutputDeviceID, audioListenerFormat.PreferredInputLatency, audioListenerFormat.PreferredOutputLatency) { }

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

        public string InputDeviceID { get; set; }
        public string OutputDeviceID { get; set; }
        public int PreferredInputLatency { get; set; }
        public int PreferredOutputLatency { get; set; }
    }
}
