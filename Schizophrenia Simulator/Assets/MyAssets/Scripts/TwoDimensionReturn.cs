using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TwoDimensionReturn : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Deactivator("none"));
	}
	
	IEnumerator Deactivator(string DisableVR)
    {
        XRSettings.LoadDeviceByName(DisableVR);
        yield return null;
        XRSettings.enabled = false;
    }
}
