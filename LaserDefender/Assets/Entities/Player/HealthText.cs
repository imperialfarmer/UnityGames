using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthText : MonoBehaviour {
	private Text myText;
	void Start(){
		myText = GetComponent<Text>();
	}
	public void ShowHealth(float hp){
		myText.text = hp.ToString();
	}
}

