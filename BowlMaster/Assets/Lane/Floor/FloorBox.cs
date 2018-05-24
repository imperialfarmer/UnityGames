using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBox : MonoBehaviour {

    private PinSetter pinSetter;

	// Use this for initialization
	void Start () {
        pinSetter = FindObjectOfType<PinSetter>();
	}

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.name == "Ball"){
            pinSetter.ballOutOfPlay = true;
        }
    }
}
