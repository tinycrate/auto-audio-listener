using NAudio.CoreAudioApi;

namespace AutoAudioListener.Audio {
    public class AudioListenerFormat : IBaseAudioListenerFormat {
        public AudioListenerFormat(
            string inputDeviceId,
            string outputDeviceId,
            int preferredInputLatency,
            int preferredOutputLatency,
            float silenceLevel,
            float activeLevel,
            double activeTimeoutMilliseconds
        ) {
            InputDeviceID = inputDeviceId;
            OutputDeviceID = outputDeviceId;
            PreferredInputLatency = preferredInputLatency;
            PreferredOutputLatency = preferredOutputLatency;
            SilenceLevel = silenceLevel;
            ActiveLevel = activeLevel;
            ActiveTimeoutMilliseconds = activeTimeoutMilliseconds;
        }

        private AudioListenerFormat() { }

        public static AudioListenerFormat Default {
            get {
                using (var devices = new MMDeviceEnumerator()) {
                    return new AudioListenerFormat(
                        devices.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia).ID,
                        devices.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia).ID,
                        100,
                        200,
                        0.0015f,
                        0.0020f,
                        2000
                    );
                }
            }
        }

        public float SilenceLevel { get; set; }
        public float ActiveLevel { get; set; }
        public double ActiveTimeoutMilliseconds { get; set; }
        public string InputDeviceID { get; set; }
        public string OutputDeviceID { get; set; }
        public int PreferredInputLatency { get; set; }
        public int PreferredOutputLatency { get; set; }
    }
}