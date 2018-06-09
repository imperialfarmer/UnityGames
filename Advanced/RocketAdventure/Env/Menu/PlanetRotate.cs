using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour {

    [SerializeField] Vector3 rotateSpeed;
	
	void Update () {
        transform.eulerAngles += rotateSpeed*Time.deltaTime;
	}
}
