using System.ComponentModel;
using System.Configuration;

namespace AutoAudioListener.Properties {
    // 這個類別可以讓您處理設定類別上的特定事件: 
    //  在設定值變更之前引發 SettingChanging 事件。
    //  在設定值變更之後引發 PropertyChanged 事件。
    //  在載入設定值之後引發 SettingsLoaded 事件。
    //  在儲存設定值之前引發 SettingsSaving 事件。
    internal sealed partial class Settings {
        private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e) {
            // 在此加入程式碼以處理 SettingChangingEvent 事件。
        }

        private void SettingsSavingEventHandler(object sender, CancelEventArgs e) {
            // 在此加入程式碼以處理 SettingsSaving 事件。
        }
    }
}