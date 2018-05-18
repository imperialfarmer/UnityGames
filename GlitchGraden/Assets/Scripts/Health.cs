using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health;
	private Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {
		
	}

	public void DealDamage(float damage){
		health -= damage;
		if(health <= 0f) {
			//DestroyObject();
			anim.SetBool("isDead", true); // TODO will be moved to health and remove collider
		}
	}

	void DestroyObject(){
		Destroy(gameObject);
	}
}
