using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoAudioListener.Audio;
using System.Diagnostics;

namespace AutoAudioListener.AppSettings {
    public class Profile {

        protected Profile() {
        }

        public static Profile Default {
            get {
                var profile = new Profile();
                profile.Name = "Default";
                profile.ActiveListenerFormat = ActiveAudioListenerFormat.Default;
                profile.AppPriority = ProcessPriorityClass.AboveNormal;
                return profile;
            }
        }

        public string Name { get; set; }
        public ActiveAudioListenerFormat ActiveListenerFormat { get; set; }
        public ProcessPriorityClass AppPriority { get; set; }
    }
}
