using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialShow : MonoBehaviour {

    private Text text;
	void Start () {
        text = GetComponent<Text>();
	}

    private void Update()
    {
        text.text = "                  " +
            PlayerPrefsManager.GiveMaterial().ToString();
    }
}
