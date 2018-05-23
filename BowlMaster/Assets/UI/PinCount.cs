using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCount : MonoBehaviour {
    
    public PinSetter pinSetter;
    private Text myText;

	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        myText.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
        myText.text = pinSetter.CountStanding().ToString();
        if(pinSetter.ballIsIn){
            myText.color = Color.red;
        }
        if(pinSetter.pinSettled && !pinSetter.ballIsIn){
            myText.color = Color.green;
        }
	}
}
