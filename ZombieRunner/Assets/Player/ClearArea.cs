using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour {

    public float timeSinceLastTrigger = 0f;
    private bool foundClearArea = false;

	void Update () {
        timeSinceLastTrigger += Time.deltaTime;

        if(timeSinceLastTrigger > 1.5f && 
           Time.realtimeSinceStartup > 10f && !foundClearArea){
            //print(name + "Send Message: OnFindClearArea");
            SendMessageUpwards("OnFindClearArea");
            foundClearArea = true;
        }
	}

    void OnTriggerStay(Collider other)
    {
        if(other.tag != "Player") timeSinceLastTrigger = 0f;
        //print(other.gameObject.name);

        GameObject others = other.gameObject;
        //print(others.name + "in clear area");
    }
}
