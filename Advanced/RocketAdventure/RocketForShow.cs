using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketForShow : MonoBehaviour {

    [SerializeField] ParticleSystem engineSmoke;
	void Start () {
        engineSmoke.Play();
	}
}
