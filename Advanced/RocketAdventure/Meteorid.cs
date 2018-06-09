using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorid : MonoBehaviour {

    [SerializeField] Vector3 speed;
    [SerializeField] float loopTime;
    [SerializeField] float delayTime;

    private Vector3 originalPos;
    private float currentTime;

	void Start () {
        originalPos = transform.position;
        currentTime = Time.timeSinceLevelLoad;
	}

    private void Update()
    {
        if(delayTime <= 0.5f )transform.position += speed * Time.deltaTime;
        if (Time.timeSinceLevelLoad - currentTime - delayTime >= loopTime)
               ResetPos();
    }

    private void ResetPos()
    {
        transform.position = originalPos;
        currentTime = Time.timeSinceLevelLoad;
        delayTime = 0f;
    }
}
