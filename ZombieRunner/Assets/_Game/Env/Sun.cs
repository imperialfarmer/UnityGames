using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

    [Tooltip("number of minutes per second")]
    public float minutesPerSecond;
	
	void Update () {
        float angleThisFrame = Time.deltaTime / 360 * minutesPerSecond;
        transform.RotateAround
                 (new Vector3(500,0,500), Vector3.back, angleThisFrame);
	}
}
