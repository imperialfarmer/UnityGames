using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour {

	public float damage, speed;

	void Start () {
		
	}

	void Update () {
		transform.Translate(Vector3.right*speed*Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log(gameObject + " Collidered with " + collider);
		Attackers attacker = collider.gameObject.GetComponent<Attackers>();
		Health health = collider.gameObject.GetComponent<Health>();

		if(attacker && health){
			health.DealDamage(damage);
			Destroy(gameObject);
		}
	}
}
