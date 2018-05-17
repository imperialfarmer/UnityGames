using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Attackers))]
public class Lizard : MonoBehaviour {

	private Animator anim;
	private Attackers attacker;

	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attackers>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log("Lizard collided with " + collider);
		GameObject obj = collider.gameObject;
		if(obj.GetComponent<Defenders>()){
			anim.SetBool("isAttacking", true);
			attacker.SetTarget(collider.gameObject);
		}
	}
}
