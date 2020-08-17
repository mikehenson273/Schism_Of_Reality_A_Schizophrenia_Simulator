using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider FGAudioValue,
                  BGAudioValue,
                  MicAudioValue;
    public void Start()
    {
        FGAudioValue.value = AppSettings.instance.foregroundAudioVolume;
        BGAudioValue.value = AppSettings.instance.backgroundAudioVolume;
        MicAudioValue.value = AppSettings.instance.MicPassVolume;
    }

    public void ForegroundAudioChange(float FGAudio) //changes foreground audio volume
    {
        AppSettings.instance.foregroundAudioVolume = FGAudio;
    }

    public void BackgroundAudioChange(float BGAudio) //changes background audio volume
    {
        AppSettings.instance.backgroundAudioVolume = BGAudio;
    }

    public void MicrophoneAudioChange(float MicAudio) //changes microphone audio volume
    {
        AppSettings.instance.MicPassVolume = MicAudio;
    }
}
