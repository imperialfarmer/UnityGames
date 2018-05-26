using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoint : MonoBehaviour {

    private Slider slider;
    private Player player;

	void Start () {
        slider = GetComponent<Slider>();
        player = FindObjectOfType<Player>();
	}
	
	void Update () {
        slider.value = player.health / 100f;
	}
}
