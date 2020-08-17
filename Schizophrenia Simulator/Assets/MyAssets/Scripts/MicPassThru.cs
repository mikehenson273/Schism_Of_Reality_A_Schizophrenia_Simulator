using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MicPassThru : MonoBehaviour
{
    public AudioSource micAudioSource;
    public AudioClip micAudioClip;

    public string selectedMic;

    public int timeAllowed;
    public int seconds_;

    private bool usingMic_;
    public bool isRecording;

	// Use this for initialization
	void Start ()
    {
        usingMic_ = AppSettings.instance.useMic;
        micAudioSource = GetComponent<AudioSource>();
        //StartCoroutine("preventRecordPlayback");

        if (usingMic_)
        {
            if (Microphone.devices.Length > 0)
            {
                isRecording = true;
                selectedMic = Microphone.devices[0].ToString();
                micAudioSource.clip = Microphone.Start(selectedMic, true, timeAllowed, 44100);
                while (!(Microphone.GetPosition(selectedMic) > 0)) { }
            }
            else
            {
                usingMic_ = false;
            }
        }
        if (!usingMic_)
        {
            micAudioSource.clip = micAudioClip;
        }

        micAudioSource.Play(); 
	}
	
	/*void FixedUpdate ()
    {
        /* not working for some reason when moving over to android device
		if (seconds_ > timeAllowed - 1 && isRecording)
        {
            micAudioClip = null;
            seconds_ = -1;
            isRecording = false;
        }
        else if (seconds_ <= 0 && !isRecording)
        {
            micAudioSource.clip = Microphone.Start(selectedMic, true, timeAllowed, 44100);
            micAudioSource.Play();
            isRecording = true;
        }*
	}*/

    IEnumerator preventRecordPlayback()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            seconds_++;
        }
    }
}