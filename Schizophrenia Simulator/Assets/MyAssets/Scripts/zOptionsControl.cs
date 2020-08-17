using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zOptionsControl : MonoBehaviour
{
    public Toggle UseCamera,
                  UsingHallucinations,
                  UseAudioSettings,
                  UsingAudioDistortions,
                  UseMicrophoneSettings,
                  UsingMicDostortions;
    void Start ()
    {
        if (AppSettings.instance.useCam)
        {
            UseCamera.isOn = AppSettings.instance.useCam;
            AppSettings.instance.useCam = true;
        }
        if(AppSettings.instance.hallucinations)
        {
            UsingHallucinations.isOn = AppSettings.instance.hallucinations;
            AppSettings.instance.hallucinations = true;
        }

        if (AppSettings.instance.useAudio)
        {
            UseAudioSettings.isOn = AppSettings.instance.useAudio;
            AppSettings.instance.useAudio = true;
        }
        if (AppSettings.instance.distortedAudio)
        {
            UsingAudioDistortions.isOn = AppSettings.instance.distortedAudio;
            AppSettings.instance.distortedAudio = true;
        }

        if (AppSettings.instance.useMic)
        {
            UseMicrophoneSettings.isOn = AppSettings.instance.useMic;
            AppSettings.instance.useMic = true;
        }
        if (AppSettings.instance.distortedMic)
        {
            UsingMicDostortions.isOn = AppSettings.instance.distortedMic;
            AppSettings.instance.distortedMic = true;
        }
	}
}
