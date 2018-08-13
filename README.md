# Auto Audio Listener

A simple tool to "listen" to an audio device, similar to Windows "Listen to this device" but with additional features. Implemented with NAudio

## Features

- Direct audio from an input device (line in/mic) to an output device
- Mute audio when input volume is below certain threshold to eliminate noise floor while nothing is playing
- Fade in when the input audio becomes alive again
- Decent looking volume meter
- Customizable settings
- Run on startup

The intended usage of this application is to connect a smartphone's 3.5mm output to the pc line-in and hear the smartphone while using the pc simultaneously through the pc's headset / speaker. This could be achieved using Windows's supplied "Listen to this device" feature but background noises could be noticeable when nothing is playing on the source (smartphone). This app mute the audio automatically when the source volume is below a certain volume threshold and resume when audio is detected again. This app could operate in fairly low latency (similar to Window's "Listen to this device") with the correct settings.
