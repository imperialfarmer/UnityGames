using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {
    
    public AudioClip callSound;
    public float arriveTime = 10f;
    public Info info;

    private AudioSource audioSource;
    private Vector3 targetPos;
    private bool called = false;

    private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
        Idle();
	}
	

    public void OnDispatchHelicopter()
    {
        if (!called)
        {
            print("Heli start to dispatch");
            called = true;
            audioSource.clip = callSound;
            audioSource.Play();

            targetPos =
                FindObjectOfType<Player>().GetComponent<Player>().landingPos;

            float diffX = targetPos.x - transform.position.x;
            float diffZ = targetPos.x - transform.position.z;

            rigidBody.velocity = 
                new Vector3(diffX/arriveTime, 0, diffZ/arriveTime);
            print(rigidBody.velocity);

            Invoke("WaitingLanding", arriveTime);
            return;
        }
    }

    private void WaitingLanding(){
        Idle();
        info.Info_WaitingForLandind();
        rigidBody.velocity = Vector3.down * 10f;

        Invoke("Idle", 10f);
    }

    private void Idle(){
        rigidBody.velocity = Vector3.zero;
    }
}
