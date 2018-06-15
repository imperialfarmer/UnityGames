using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoint : MonoBehaviour {
    
    private Slider slider;
    public Player player;

	void Start () {
        slider = GetComponent<Slider>();
        slider.value = player.health / 100f;
        //print("Health Slider = " + (player.health / 100f).ToString());
	}
	
	void Update () {
        slider.value = player.health / 100f;
        //print("Health Slider = " + (player.health / 100f).ToString());
	}
}
