using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Attackers))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attackers attacker;

	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attackers>();
	}
	

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		//Debug.Log("Fox collided with " + collider);
		GameObject obj = collider.gameObject;
		if(obj.GetComponent<Defenders>()){
			if(obj.GetComponent<GraveStone>()){
				anim.SetTrigger("jumpTrigger");
			}else{
				anim.SetBool("isAttacking", true);
				attacker.SetTarget(collider.gameObject);
			}
		}
	}
}
