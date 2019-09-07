using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.CoreAudioApi;

namespace AutoAudioListener.Audio {
    public abstract class BaseAudioListener : IDisposable {

        private MMDevice inputDevice;
        private MMDevice outputDevice;
        private WasapiCapture inputStream;
        private WasapiOut outputStream;
        private VolumeSampleProvider volumeControl;

        public BaseAudioListener(IBaseAudioListenerFormat listenerFormat) {
            this.Format = listenerFormat;
            InitializeDevices();
            InitializeInputStream();
            InitializeVolumeControl();
            InitializeOutputStream();
        }

        public IBaseAudioListenerFormat Format { get; }
        public bool Listening {
            get {
                return inputStream.CaptureState == CaptureState.Capturing;
            }
        }
        public float CurrentOutputVolume {
            get {
                return volumeControl.Volume;
            }
            set {
                volumeControl.Volume = value;
            }
        }
        public float CurrentSourceVolume {
            get {
                return inputDevice.AudioMeterInformation.MasterPeakValue;
            }
        }
        public float CurrentSourceVolumeLeft {
            get {
                int channelCount = inputDevice.AudioMeterInformation.PeakValues.Count;
                if (channelCount >= 1 && channelCount <= 2) {
                    return inputDevice.AudioMeterInformation.PeakValues[0];
                } else {
                    throw new NotImplementedException("Audio Listener:: Audio streams other than mono or stereo are currently not supported.");
                }
            }
        }
        public float CurrentSourceVolumeRight {
            get {
                int channelCount = inputDevice.AudioMeterInformation.PeakValues.Count;
                if (channelCount == 2) {
                    return inputDevice.AudioMeterInformation.PeakValues[1];
                } else if (channelCount == 1) { // Mono stream
                    return inputDevice.AudioMeterInformation.PeakValues[0];
                } else {
                    throw new NotImplementedException("Audio Listener:: Audio streams other than mono or stereo are currently not supported.");
                }
            }
        }
        public event EventHandler<StoppedEventArgs> ListeningStopped {
            add {
                inputStream.RecordingStopped += value;
            }
            remove {
                inputStream.RecordingStopped -= value;
            }
        }

        public virtual void StartListening() {
            outputStream.Play();
            inputStream.StartRecording();
        }

        public virtual void StopListening() {
            outputStream.Stop();
            inputStream.StopRecording();
        }

        public virtual void Dispose() {
            inputStream.Dispose();
            outputStream.Dispose();
            inputDevice.Dispose();
            outputDevice.Dispose();
        }

        private void InitializeDevices() {
            using (var devices = new MMDeviceEnumerator()) {
                inputDevice = devices.GetDevice(Format.InputDeviceID);
                outputDevice = devices.GetDevice(Format.OutputDeviceID);
            }
        }

        private void InitializeInputStream() {
            inputStream = new WasapiCapture(inputDevice, false, Format.PreferredInputLatency);
        }

        private void InitializeVolumeControl() {
            var inputStreamProvider = new WaveInProvider(inputStream);
            ISampleProvider inputStreamSampleProvider;
            if (inputStreamProvider.WaveFormat.BitsPerSample == 64) {
                inputStreamSampleProvider = new WaveToSampleProvider64(inputStreamProvider);
            } else {
                inputStreamSampleProvider = new WaveToSampleProvider(inputStreamProvider);
            }
            volumeControl = new VolumeSampleProvider(inputStreamSampleProvider);
        }

        private void InitializeOutputStream() {
            outputStream = new WasapiOut(outputDevice, AudioClientShareMode.Shared, false, Format.PreferredOutputLatency);
            var convertedInputStreamProvider = new SampleToWaveProvider(volumeControl);
            outputStream.Init(convertedInputStreamProvider);
        }
    }
}
