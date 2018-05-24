using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;
    private Rigidbody rigidBody;
    private AudioSource audioSource;

    private Vector3 ballStartPos;

    public bool inPlay = false;

    public float movement;

	// Use this for initialization
	void Start ()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        ballStartPos = transform.position;
    }

    public void Launch(Vector3 velocity)
    {
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;

        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void moveRight(){
        if (!inPlay)
        {
            if (transform.position.x <=
                    105f / 2f - transform.localScale.x / 2f - movement)
            {
                transform.position += Vector3.right * movement;
            }
        }
    }
    public void moveLeft()
    {
        if (!inPlay)
        {
            if (transform.position.x >=
                    -105f / 2f + transform.localScale.x / 2f + movement)
            {
                transform.position += Vector3.left * movement;
            }
        }
    }

    public void Reset()
    {
        inPlay = false;
        transform.position = ballStartPos;
        transform.rotation = Quaternion.identity;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().useGravity = false;
    }
}
