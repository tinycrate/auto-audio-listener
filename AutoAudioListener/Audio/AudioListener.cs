using System;
using System.ComponentModel;
using System.Timers;

namespace AutoAudioListener.Audio {
    public class AudioListener : BaseAudioListener {
        private Timer timer;

        public AudioListener(AudioListenerFormat listenerFormat, ISynchronizeInvoke synchronizingObject) : base(
            listenerFormat
        ) {
            MuteAudio();
            InitializeTimer(synchronizingObject);
        }

        public AudioListenerFormat Format => (AudioListenerFormat) base.Format;

        public bool AudioActive { get; private set; }
        public DateTime LastActiveTime { get; private set; } = DateTime.Now;

        private bool ActiveAudioExpired =>
            DateTime.Now.Subtract(LastActiveTime).TotalMilliseconds > Format.ActiveTimeoutMilliseconds;

        public event EventHandler AudioActivated;
        public event EventHandler AudioDeactivated;
        public event EventHandler BufferVolumeTriggered;
        public event EventHandler OutputVolumeUpdated;
        public event EventHandler OutputVolumeChanged;

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
            timer = new Timer(1) {
                SynchronizingObject = synchronizingObject
            };
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
            } else {
                if (sourceVolume < Format.SilenceLevel) {
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
            CurrentOutputVolume = (volume - Format.SilenceLevel) / (Format.ActiveLevel - Format.SilenceLevel);
            BufferVolumeTriggered?.Invoke(this, EventArgs.Empty);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            UpdateOutputVolume();
        }
    }
}