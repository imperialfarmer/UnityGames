using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour {

    private Camera camera;

	void Start () {
        camera = GetComponent<Camera>();

        if (PlayerPrefsManager.CheckResolution("res_0_")) camera.fieldOfView = 57;
        if (PlayerPrefsManager.CheckResolution("res_1_")) camera.fieldOfView = 56;
        if (PlayerPrefsManager.CheckResolution("res_2_")) camera.fieldOfView = 55;
        if (PlayerPrefsManager.CheckResolution("res_3_")) camera.fieldOfView = 48;
        if (PlayerPrefsManager.CheckResolution("res_4_")) camera.fieldOfView = 45;
	}
	
}
