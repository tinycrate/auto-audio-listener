namespace AutoAudioListener.Audio {
    public interface IBaseAudioListenerFormat {
        string InputDeviceID { get; set; }
        string OutputDeviceID { get; set; }
        int PreferredInputLatency { get; set; }
        int PreferredOutputLatency { get; set; }
    }
}