using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour {

    private Camera ca;
    public float movingTime;

    private void Start()
    {
        ca = GetComponent<Camera>();
    }
    void Update () {
        if (Time.timeSinceLevelLoad < movingTime)
        {
            ca.fieldOfView += 0.1f;
        }
	}
}
