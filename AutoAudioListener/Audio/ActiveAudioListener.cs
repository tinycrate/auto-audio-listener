using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAudioListener.Audio {
    public class ActiveAudioListener : AudioListener {

        public ActiveAudioListener(ActiveAudioListenerFormat activeListenerFormat, ISynchronizeInvoke synchronizingObject) : base(activeListenerFormat) {
            MuteAudio();
            InitializeTimer(synchronizingObject);
        }

        public event EventHandler AudioActivated;
        public event EventHandler AudioDeactivated;
        public event EventHandler BufferVolumeTriggered;
        public event EventHandler OutputVolumeUpdated;
        public event EventHandler OutputVolumeChanged;

        public new ActiveAudioListenerFormat Format {
            get {
                return (ActiveAudioListenerFormat)base.Format;
            }
        }
        public bool AudioActive { get; private set; } = false;
        public DateTime LastActiveTime { get; private set; } = DateTime.Now;

        private System.Timers.Timer timer;

        private bool ActiveAudioExpired {
            get {
                return DateTime.Now.Subtract(LastActiveTime).TotalMilliseconds > Format.ActiveTimeoutMilliseconds;
            }
        }

        public override void StartListening() {
            base.StartListening();
            timer.Start();
        }

        public override void StopListening() {
            base.StopListening();
            timer.Stop();
            MuteAudio();
        }

        public override void Dispose() {
            base.Dispose();
            timer.Dispose();
        }

        private void InitializeTimer(ISynchronizeInvoke synchronizingObject) {
            timer = new System.Timers.Timer(1);
            timer.SynchronizingObject = synchronizingObject;
            timer.Elapsed += Timer_Elapsed;
        }

        private void UpdateOutputVolume() {
            float sourceVolume = CurrentSourceVolume;
            float outputVolume = CurrentOutputVolume;
            if (AudioActive) {
                if (ActiveAudioExpired && sourceVolume < Format.ActiveLevel) {
                    DeactivateAudio();
                } else {
                    AudioFadein();
                    if (sourceVolume > Format.ActiveLevel) KeepAudioAlive();
                }
            } 
            else {
                if (sourceVolume < Format.SlienceLevel) {
                    AudioFadeout();
                } else if (sourceVolume < Format.ActiveLevel) {
                    TriggerBufferVolume(sourceVolume);
                } else {
                    ActivateAudio();
                }
            }
            if (outputVolume != CurrentOutputVolume) OutputVolumeChanged?.Invoke(this, EventArgs.Empty);
            if (timer.Enabled) OutputVolumeUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void ActivateAudio() {
            CurrentOutputVolume = Math.Max(CurrentOutputVolume, 0.01f);
            AudioActive = true;
            LastActiveTime = DateTime.Now;
            AudioActivated?.Invoke(this, EventArgs.Empty);
        }

        private void KeepAudioAlive() {
            LastActiveTime = DateTime.Now;
        }

        private void DeactivateAudio() {
            AudioActive = false;
            AudioDeactivated?.Invoke(this, EventArgs.Empty);
        }

        private void AudioFadein() {
            CurrentOutputVolume = Math.Min(1, CurrentOutputVolume * 2f);
        }

        private void AudioFadeout() {
            if (CurrentOutputVolume > 0.001) {
                CurrentOutputVolume /= 1.1f;
            } else {
                CurrentOutputVolume = 0;
            }
        }

        private void MuteAudio() {
            CurrentOutputVolume = 0;
        }

        private void TriggerBufferVolume(float volume) {
            CurrentOutputVolume = (volume - Format.SlienceLevel) / (Format.ActiveLevel - Format.SlienceLevel);
            BufferVolumeTriggered?.Invoke(this, EventArgs.Empty);
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
            UpdateOutputVolume();
        }
    }
}
