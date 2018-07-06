using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAudioListener.Utils {
    public class AutoStartup {

        public static readonly string AutostartFlag = "/autostart";

        public static bool Enabled {
            get {
                var reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);
                return reg.GetValue(Application.ProductName) != null;
            }
            set {
                var reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (value) {
                    reg.SetValue(Application.ProductName, $"\"{Application.ExecutablePath}\" {AutostartFlag}");
                } else {
                    reg.DeleteValue(Application.ProductName, false);
                }
            }
        }

        public static bool IsLaunchedFromAutostart {
            get {
                var args = Environment.GetCommandLineArgs();
                return args.Contains(AutostartFlag);
            }
        }

    }
}
