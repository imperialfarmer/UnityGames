using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

	// turn position into a prefab, 
	// which can be accessed by enemySpawner
	void OnDrawGizmos(){
		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}
}
