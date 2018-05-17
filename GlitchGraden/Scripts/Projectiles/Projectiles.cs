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
}
