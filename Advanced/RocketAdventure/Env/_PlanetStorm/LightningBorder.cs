using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBorder : MonoBehaviour {

    [SerializeField] float musicInterval = 3f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("PlayMusic", musicInterval);
	}

    void PlayMusic(){
        GetComponent<AudioSource>().Play();
    }
}
