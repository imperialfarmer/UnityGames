using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliMoving : MonoBehaviour {

	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(1f, 0, -1f);
	}

}
