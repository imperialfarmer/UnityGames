using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Ball ball;
    private Vector3 distanceToBall;

	// Use this for initialization
    void Start () {
        distanceToBall = - ball.transform.position + transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = ball.transform.position + distanceToBall;
	}
}
