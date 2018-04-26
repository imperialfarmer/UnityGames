using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	// once you define this class, the LoseCollider will
	// ask you to give the class to feed
	private LevelManager levelManager;

	// if trigger, this function will be called
	// the name of this function is fixed
	// Unity will only call the function with this name
	// you canNOT define this in a different name
	void OnTriggerEnter2D(Collider2D collider){
		// by doing this, prefabs can be very fast and efficient
		//levelManager = GameObject.FindObjectOfType<LevelManager>();
		Debug.Log("Trigger Lose");
		//levelManager.LoadLever("Lose");
	}
	// if conllision, this function will be called
	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log("Collision");
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadLever("Lose");
	}
}
