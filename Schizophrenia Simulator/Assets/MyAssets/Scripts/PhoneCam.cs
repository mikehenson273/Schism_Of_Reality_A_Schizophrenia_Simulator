using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class PhoneCam : MonoBehaviour
{ 
    #region Bools
    private bool camAvalaible_;
    #endregion

    #region Textures
    public AspectRatioFitter fit; //fits camera to an aspect ratio
    public RawImage backGround; //places background or feed here
    private WebCamTexture backCam_; //uses camera as texture
    private Texture defaultBackground_; //uses a default background in case no camera device
    #endregion

    // Use this for initialization
    void Start ()
    {
        //defaultBackground_ = backGround.texture;
        //StartCoroutine(ActivatorVR("cardboard"));
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            Debug.Log("NO CAMERA FOUND");
            camAvalaible_ = false;
            return;
        }

        for(int i = 0; i < devices.Length; i++)
        {
            if (!devices[i].isFrontFacing)
            {
                backCam_ = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (backCam_ == null)
        {
            Debug.Log("No back camera");
            return;
        }

        backCam_.Play();
        backGround.texture = backCam_;

        camAvalaible_ = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!camAvalaible_)
        {
            return;
        }

        float ratio = (float)backCam_.width / (float)backCam_.height;
        fit.aspectRatio = ratio;
        float scaleY = backCam_.videoVerticallyMirrored ? -1f : 1f;
        backGround.rectTransform.localScale = new Vector3(1f, scaleY, 1f);
        int orient = -backCam_.videoRotationAngle;
        backGround.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
	}

    IEnumerator ActivatorVR(string VREnabled)
    {
        XRSettings.LoadDeviceByName(VREnabled);
        yield return null;
        XRSettings.enabled = true;
    }
}
