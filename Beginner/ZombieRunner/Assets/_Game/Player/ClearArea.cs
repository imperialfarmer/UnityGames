using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearArea : MonoBehaviour {

    public float timeSinceLastTrigger = 0f;
    private bool foundClearArea = false;
    public Info info;

	void Update () {
        timeSinceLastTrigger += Time.deltaTime;

        if(timeSinceLastTrigger > 1.5f && 
           Time.realtimeSinceStartup > 12f && !foundClearArea){
            //print(name + "Send Message: OnFindClearArea");
            SendMessageUpwards("OnFindClearArea");
            info.Info_LandingAreaSpotted();
            foundClearArea = true;
        }
	}

    void OnTriggerStay(Collider other)
    {
        if (!foundClearArea)
        {
            if (other.tag != "Player" && other.tag != "GameController") timeSinceLastTrigger = 0f;
            //print(other.gameObject.name);

            GameObject others = other.gameObject;
            //print(others.name + "in clear area");
        }
    }
}
