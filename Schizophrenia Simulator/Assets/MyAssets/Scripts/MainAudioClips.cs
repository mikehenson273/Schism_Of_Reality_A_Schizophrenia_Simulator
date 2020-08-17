using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioClips : MonoBehaviour
{
    public AudioClip[] toPlay;
    private AudioClip currentlyPlaying_;
    private AudioSource mySource1_;
    private AudioSource mySource2_;
    private AudioClip PreviouslyPlayed_;
    private int switchingTo_;

    private bool isPlaying_;

    // Use this for initialization
    void Start()
    {
        mySource1_ = gameObject.AddComponent<AudioSource>();
        mySource2_ = gameObject.AddComponent<AudioSource>();
        AudioSettings();
        isPlaying_ = false;
    }

    void Update()
    {
        RandomPlaying();
    }

    void RandomPlaying()
    {
        if (!isPlaying_ && (!mySource1_.isPlaying || !mySource2_.isPlaying))
        {
            switchingTo_ = Random.Range(0, toPlay.Length);
            currentlyPlaying_ = toPlay[switchingTo_];

            mySource1_.PlayOneShot(currentlyPlaying_);
            mySource2_.PlayOneShot(currentlyPlaying_);

            PreviouslyPlayed_ = currentlyPlaying_;
        }

    }

    void AudioSettings()
    {
        mySource1_.volume = AppSettings.instance.foregroundAudioVolume;
        mySource2_.volume = AppSettings.instance.foregroundAudioVolume;
        mySource1_.minDistance = 0.1f;
        mySource1_.maxDistance = 1.1f;
        mySource1_.spatialBlend = 1f;
        mySource1_.panStereo = -1f;
        mySource2_.minDistance = 0.1f;
        mySource2_.maxDistance = 1.1f;
        mySource2_.spatialBlend = 1f;
        mySource2_.panStereo = 1f;
    }
}
