using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {
    
    public float arriveTime = 10f;
    public float landingTime = 5f;
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

            targetPos =
                FindObjectOfType<Player>().GetComponent<Player>().landingPos;

            float diffX = targetPos.x - transform.position.x;
            float diffZ = targetPos.z - transform.position.z;

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
        float diffY = - targetPos.y + transform.position.y;
        rigidBody.velocity = Vector3.down * diffY/landingTime;

        Invoke("Idle", landingTime - 0.4f);
    }

    private void Idle(){
        rigidBody.velocity = Vector3.zero;
    }
}
