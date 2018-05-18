using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackers : MonoBehaviour {

	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left*currentSpeed*Time.deltaTime);
		anim = GetComponent<Animator>();
		if(!currentTarget) anim.SetBool("isAttacking", false);
	}

	void OnTriggerEnter2D(){
		//Debug.Log(name + "Attacker Triggered");
	}

	public void SetSpeed(float speed){
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage){
		if(currentTarget){ 
			Health targetHealth = currentTarget.GetComponent<Health>();
			if(targetHealth){
				targetHealth.DealDamage(damage);
			}
		}
	}

	public void SetTarget(GameObject obj){
		currentTarget = obj;
	}

	public void DestroyAttacker(){
		Destroy(gameObject);
	}
}

