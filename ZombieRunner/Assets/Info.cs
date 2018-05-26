using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour {

    private Text text;
    private string heliWaitingForLanding = 
        "Helicopter has arrived the target area, " +
        "but it is having diffulties in landing." +
        "Make sure you can survive until pilots fix the problem!";
    void Start () {
        text = GetComponent<Text>();
        RemoveText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Info_WaitingForLandind(){
        text.text = heliWaitingForLanding;
        Invoke("RemoveText", 10f);
    }

    void RemoveText(){
        text.text = "";
    }
}
