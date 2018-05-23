using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 3f;

	// Use this for initialization
	void Start () {
        //print(name + " " + isStanding());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public bool isStanding(){
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        //print(name + " " + rotationInEuler);
        float tiltInX = 
            Mathf.Abs(rotationInEuler.x) > Mathf.Abs(rotationInEuler.x - 360f) ?
            Mathf.Abs(rotationInEuler.x - 360f) : Mathf.Abs(rotationInEuler.x);
        float tiltInZ = 
            Mathf.Abs(rotationInEuler.z) > Mathf.Abs(rotationInEuler.z - 360f) ?
            Mathf.Abs(rotationInEuler.z - 360f) : Mathf.Abs(rotationInEuler.z);

        if (tiltInX <= standingThreshold &&
           tiltInZ <= standingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
