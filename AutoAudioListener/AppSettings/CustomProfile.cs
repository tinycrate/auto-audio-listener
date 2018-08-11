using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoAudioListener.Audio;
using System.Xml;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace AutoAudioListener.AppSettings {
    public class CustomProfile : Profile {

        public static readonly string UserProfilePath = Path.Combine(Application.LocalUserAppDataPath, "Profiles");
        public static readonly string NewProfileName = "Profile";
        public static readonly string ProfileExtension = "cfg";

        static CustomProfile() {
            if (!EnumerateProfiles().Any()) {
                CreateDefaultProfile();
            }    
        }    

        public static IEnumerable<CustomProfile> EnumerateProfiles() {
            if (!Directory.Exists(UserProfilePath)) yield break;
            foreach (string filePath in Directory.EnumerateFiles(UserProfilePath)) {
                CustomProfile profile;
                try {
                    profile = ParseProfile(filePath);
                } catch (Exception e) {
                    if (e is XmlException || e is InvalidOperationException) {
                        Debug.WriteLine($"Failed parsing profile at {filePath}, ignoring... ", e);
                        continue;
                    }
                    throw;
                }
                yield return profile;
            }
        }

        public static CustomProfile NewProfile(string name, ActiveAudioListenerFormat activeListenerFormat, ProcessPriorityClass appPriority) {
            CustomProfile profile = new CustomProfile();
            profile.Name = name;
            profile.ActiveListenerFormat = activeListenerFormat;
            profile.AppPriority = appPriority;
            UpdateProfile(profile);
            return profile;
        }

        public static CustomProfile NewProfileFromDefault() {
            var profileNames = EnumerateProfiles().Select(x => x.Name);
            int profileSuffix = 1;
            while (profileNames.Contains(NewProfileName + profileSuffix)) {
                profileSuffix++;
            }
            return NewProfile(NewProfileName + profileSuffix, Default.ActiveListenerFormat, Default.AppPriority);
        }

        public static CustomProfile CreateDefaultProfile() {
            return NewProfile(Default.Name, Default.ActiveListenerFormat, Default.AppPriority);
        }

        public static void UpdateProfile(CustomProfile profile) {
            var serializer = new XmlSerializer(typeof(CustomProfile));
            if (!Directory.Exists(UserProfilePath)) Directory.CreateDirectory(UserProfilePath);
            using (var writer = new StreamWriter(profile.FilePath, false)) {
                profile.DateModified = DateTime.Now;
                serializer.Serialize(writer, profile);
            }
        }

        public static CustomProfile GetProfile(string id) {
            return ParseProfile(GetProfilePath(id));
        }

        public static string GetProfilePath(string id) {
            return Path.ChangeExtension(Path.Combine(UserProfilePath, id), ProfileExtension);
        }

        public static void DeleteProfile(CustomProfile profile) {
            if (File.Exists(profile.FilePath)) {
                File.Delete(profile.FilePath);
            } else {
                Debug.WriteLine($"Profile delete failed. Profile does not exist at {profile.FilePath}. It has either been deleted or was not created. Ignoring...");
            }
        }

        private static CustomProfile ParseProfile(string fileName) {
            var deserializer = new XmlSerializer(typeof(CustomProfile));
            using (var reader = new StreamReader(fileName)) {
                return (CustomProfile)deserializer.Deserialize(reader); ;
            }
        }

        private CustomProfile() {   
        }

        /* A rather bizarre implementation of the Id property to workaround XmlSerializer not serializing private setter property */
        private string _id = "";
        public string Id {
            get {
                if (_id == "") _id = System.Guid.NewGuid().ToString("N");
                return _id;
            }
            set {
                if (_id == "") _id = value;
            }
        }

        public string FilePath {
            get {
                return GetProfilePath(Id);
            }
        }

        public DateTime DateModified { get; set; }

        public void SaveChanges() {
            if (ValidateData()) {
                UpdateProfile(this);
            } else {
                throw new InvalidDataException("Data validation failed. Check before saving!");
            }
        }

        public void DiscardChanges() {
            CopySettingsFrom(GetProfile(this.Id));
        }

        public void RestoreDefault() {
            CopySettingsFrom(Default);
        }

        public bool ValidateData() {
            if (ActiveListenerFormat.SlienceLevel >= 0 && ActiveListenerFormat.SlienceLevel <= 1 &&
                ActiveListenerFormat.ActiveLevel >= 0 && ActiveListenerFormat.ActiveLevel <= 1 &&
                ActiveListenerFormat.PreferredInputLatency > 0 && ActiveListenerFormat.PreferredOutputLatency > 0 &&
                ActiveListenerFormat.ActiveLevel >= ActiveListenerFormat.SlienceLevel
                ) {
                return true;
            } else {
                return false;
            }
        }

        public void CopySettingsFrom(Profile profile) {
            this.ActiveListenerFormat = profile.ActiveListenerFormat;
            this.AppPriority = profile.AppPriority;
        }

    }
}
