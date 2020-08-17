using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningWarnings : MonoBehaviour
{
    public GameObject Warning,
                      Disclaimer;

    public float warningTimer, //warning (use to say it MIGHT bring unwanted feelings and if one feels that they experience it on a frequent basis then seek help
                 disclaimerTimer; //to inform that this is not an accurate representation of schizophrenia but merely an emulation of it and to inquire about it with those
                                  //diagnosed with it and medical professionals
    private int seconds_;
    // Use this for initialization
	void Start ()
    {
        StartCoroutine("InformationTimer");
        StopCoroutine("InformationTimer");
        LoadScene("MainMenu");
	}

    IEnumerator InformationTimer()
    {
        while (true)
        {
            Warning.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            seconds_++;
            if (seconds_ >= warningTimer)
            {
                Warning.gameObject.SetActive(false);
                Disclaimer.gameObject.SetActive(true);
                seconds_ = 0;
            }
            yield return new WaitForSeconds(1);
            seconds_++;
            if (seconds_ >= disclaimerTimer)
            {
                Disclaimer.gameObject.SetActive(false);
                seconds_ = 0;
            }
        }
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
