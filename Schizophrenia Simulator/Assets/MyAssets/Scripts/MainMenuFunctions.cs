using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{
    public void ActivateCam(bool CamActivation)
    {
        if (AppSettings.instance.useCam)
        {
            AppSettings.instance.useCam = false;
        }

        else if (!AppSettings.instance.useCam)
        {
            AppSettings.instance.useCam = true;
        }
    }
    public void Hallucinating(bool HallucinationsActive)
    {
        if (AppSettings.instance.hallucinations)
        {
            AppSettings.instance.hallucinations = false;
        }

        else if (!AppSettings.instance.hallucinations)
        {
            AppSettings.instance.hallucinations = true;
        }
    }

    public void ActivateMic(bool MicActivation)
    {
        if (AppSettings.instance.useMic)
        {
            AppSettings.instance.useMic = false;
        }

        else if (!AppSettings.instance.useMic)
        {
            AppSettings.instance.useMic = true;
        }
    }
    public void DistortedMic(bool MicDistortion)
    {
        if (AppSettings.instance.distortedMic)
        {
            AppSettings.instance.distortedMic = false;
        }

        else if (!AppSettings.instance.distortedMic)
        {
            AppSettings.instance.distortedMic = true;
        }
    }

    public void ActivateAudio(bool AudioActivation)
    {
        if (AppSettings.instance.useAudio)
        {
            AppSettings.instance.useAudio = false;
        }

        else if (!AppSettings.instance.useAudio)
        {
            AppSettings.instance.useAudio = true;
        }
    }
    public void DistortedAudio(bool AudioDistortion)
    {
        if (AppSettings.instance.distortedAudio)
        {
            AppSettings.instance.distortedAudio = false;
        }

        else if (!AppSettings.instance.distortedAudio)
        {
            AppSettings.instance.distortedAudio = true;
        }
    }

    public void LoadScene(string SceneName)
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneName);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
