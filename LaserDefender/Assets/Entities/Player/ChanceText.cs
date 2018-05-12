using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChanceText : MonoBehaviour {
	private Text myText;
	void Start () {
		myText = GetComponent<Text>();
	}
	public void ShowChance(int chance){
		myText.text = chance.ToString();
	}
}

