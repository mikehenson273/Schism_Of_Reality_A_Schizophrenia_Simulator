using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    #region objects
    public GameObject mainCamera;
    public GameObject phoneBackground;
    public GameObject defaultBackground;
    public GameObject Microphone;
    public GameObject AudioManager;
    public GameObject EntityModel1;
    public GameObject EntityModel2;
    #endregion

    private float secondsUntilEntity_,
                 seconds_;

    private int entityToSpawn_;

    private bool entitySpawned_,
                isSpawning,
                checkedCam_;

    void Start()
    {
        isSpawning = false;
    }

    void FixedUpdate ()
    {
        #region camera turn on/off
        if (AppSettings.instance.useCam)
        {
            mainCamera.gameObject.SetActive(true);
            phoneBackground.gameObject.SetActive(true);
            defaultBackground.gameObject.SetActive(false);
            mainCamera.gameObject.GetComponent<PhoneCam>().enabled = true;
        }
        else
        {
            mainCamera.gameObject.SetActive(true);
            phoneBackground.gameObject.SetActive(false);
            defaultBackground.gameObject.SetActive(true);
            mainCamera.gameObject.GetComponent<PhoneCam>().enabled = false;
            //Debug.Log("Camera" +
               // " was not turned on");
        }
        #endregion
        #region Mic On/Off
        if (AppSettings.instance.useMic)
        {
            Microphone.gameObject.SetActive(true);
        }
        else
        {
            Microphone.gameObject.SetActive(false);
            //Debug.Log("Mic was not turned on");
        }
        #endregion
        #region Turn Audio On
        if (AppSettings.instance.useAudio)
        {
            AudioManager.gameObject.SetActive(true);
        }
        else
        {
            AudioManager.gameObject.SetActive(false);
            //Debug.Log("Audio was not turned on");
        }
        #endregion
        #region entity spawn
        if (AppSettings.instance.useCam)
        {
            checkedCam_ = true;
            if (checkedCam_ && !isSpawning)
            {
                secondsUntilEntity_ = Random.Range(60, 181);
                entitySpawned_ = false;
                isSpawning = true;
                StartCoroutine("EntitySpawn");
            }
            if (entitySpawned_)
            {
                seconds_ = 0;
                secondsUntilEntity_ = Random.Range(60, 181);
                entityToSpawn_ = Random.Range(1, 3);
                if (entityToSpawn_ == 1)
                {
                    EntityModel1.SetActive(true);
                    //Debug.Log("Entity 1 Spawned");
                    entitySpawned_ = false;
                }
                else if (entityToSpawn_ == 2)
                {
                    EntityModel2.SetActive(true);
                    //Debug.Log("Entity 2 Spawned");
                    entitySpawned_ = false;
                }
                else
                {
                    EntityModel1.SetActive(true);
                    //Debug.Log("Default Entity Spawned");
                    entitySpawned_ = false;
                }
            }
            if (seconds_ >= secondsUntilEntity_)
            {
                entitySpawned_ = true;
            }
        }
        #endregion
    }

    IEnumerator EntitySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            seconds_++;
        }
    }
}