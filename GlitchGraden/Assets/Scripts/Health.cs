using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health;

	void Start () {
		
	}

	void Update () {
		
	}

	public void DealDamage(float damage){
		health -= damage;
		if(health <= 0f) {
		// TODO add die animation
			DestroyObject();
		}
	}

	void DestroyObject(){
		Destroy(gameObject);
	}
}
