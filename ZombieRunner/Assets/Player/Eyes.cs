using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour {

    private Camera eyes;
    private float defaultFOV;

	void Start () {
        eyes = GetComponent<Camera>();
        defaultFOV = eyes.fieldOfView;
	}
	
	void Update () {
        ZoomIn();
	}

    private void ZoomIn(){
        if(Input.GetButton("Zoom")){
            Debug.Log("V is pressed");
            eyes.fieldOfView = defaultFOV / 1.5f;
        }
        else
        {
            eyes.fieldOfView = defaultFOV;
        }
    }
}
