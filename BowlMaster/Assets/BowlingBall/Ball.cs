using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float launchSpeed;
    private Rigidbody rigidBody;
    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();

        BallLaunch();
    }

    public void BallLaunch()
    {
        rigidBody.velocity = new Vector3(0f, 0f, launchSpeed);
        audioSource.Play();
    }

	// Update is called once per frame
	void Update () {

	}
}
