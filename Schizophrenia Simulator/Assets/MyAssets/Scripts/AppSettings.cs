using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppSettings : MonoBehaviour
{
    #region app objects
    public static AppSettings instance;
    #endregion

    #region settings using floats/ints
    public float MicPassVolume,
                 foregroundAudioVolume,
                 backgroundAudioVolume,
                 ExposureValue;
    #endregion

    #region bool
    public bool useCam,
                useMic,
                useAudio,
                distortedAudio,
                distortedMic,
                hallucinations;
    #endregion

    #region TOGGLE

    #endregion

    // Use this for initialization
    void Awake ()
    {
		if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            //Debug.Log("INSTANCE WAS ALREADY CREATED - DESTROYING NEW INSTANCE");
        }
    }
}