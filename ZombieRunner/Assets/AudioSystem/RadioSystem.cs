using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour {

    public AudioClip initialHeliCall;
    public AudioClip initialCallReply;

    private AudioSource audioSource;
    public Helicopter helicopter;

	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		
	}

    void OnMakeInitialHeliCall(){
        print(name + "OnMakeInitialHeliCall");
        audioSource.clip = initialHeliCall;
        audioSource.Play();

        Invoke("InitialReply", initialHeliCall.length + 2f);
    }

    void InitialReply(){
        audioSource.clip = initialCallReply;
        audioSource.Play();
        helicopter.OnDispatchHelicopter();
    }
}
