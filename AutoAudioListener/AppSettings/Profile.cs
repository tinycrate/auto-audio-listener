using System.Diagnostics;
using AutoAudioListener.Audio;

namespace AutoAudioListener.AppSettings {
    public class Profile {
        protected Profile() { }

        public static Profile Default {
            get {
                var profile = new Profile();
                profile.Name = "Default";
                profile.ListenerFormat = AudioListenerFormat.Default;
                profile.AppPriority = ProcessPriorityClass.AboveNormal;
                return profile;
            }
        }

        public string Name { get; set; }
        public AudioListenerFormat ListenerFormat { get; set; }
        public ProcessPriorityClass AppPriority { get; set; }
    }
}