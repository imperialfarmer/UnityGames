using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour {

	public float damage = 100f;

	public float ReturnDamage(){
		return damage;
	}

	public void Hit(){
		Destroy(gameObject);
	}

}
