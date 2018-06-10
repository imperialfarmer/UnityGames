using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorid : MonoBehaviour {

    [SerializeField] Vector3 speed;
    [SerializeField] float loopTime;
    [SerializeField] float delayTime;

    private bool waiting = true;

    private Vector3 originalPos;
    private float currentTime = 0f;
    private float lastTime = 0f;

	void Start () {
        originalPos = transform.position;
        currentTime = Time.timeSinceLevelLoad;
        lastTime = currentTime + delayTime;
	}

    private void Update()
    {
        currentTime = Time.timeSinceLevelLoad;
        if (currentTime > lastTime) {
            waiting = false;
        }
        if(!waiting) transform.position += speed * Time.deltaTime;
        if (currentTime - lastTime >= loopTime)
               ResetPos();
    }

    private void ResetPos()
    {
        transform.position = originalPos;
        lastTime = Time.timeSinceLevelLoad;       
    }
}
