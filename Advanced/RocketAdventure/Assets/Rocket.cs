using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public float thrustPowerPerFrame = 50f;
    public float rotatePowerPerFrame = 300f;

    private Rigidbody rigidbody;
    private AudioSource audioSource;

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {
        Thrust();
        Rotate();
	}

    private void Thrust(){
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            rigidbody.AddRelativeForce
                     (Vector3.up * thrustPowerPerFrame);
            if (!audioSource.isPlaying) audioSource.Play();
        } else
        {
            audioSource.Stop();
        }
    }

    private void Rotate(){
        rigidbody.freezeRotation = true;
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D pressed");
            transform.Rotate
                     (Vector3.back * rotatePowerPerFrame * Time.deltaTime);
            rigidbody.AddRelativeForce
                     (Vector3.right * rotatePowerPerFrame * Time.deltaTime);
            //rigidbody.AddRelativeTorque
            //         (Vector3.back * rotatePowerPerFrame * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A pressed");
            transform.Rotate
                     (Vector3.forward * rotatePowerPerFrame * Time.deltaTime);
            rigidbody.AddRelativeForce
                     (Vector3.left * rotatePowerPerFrame * Time.deltaTime);
            //rigidbody.AddRelativeTorque
                     //(Vector3.forward * rotatePowerPerFrame * Time.deltaTime);
        }
        rigidbody.freezeRotation = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject colObj = collision.gameObject;
        switch(colObj.tag){
            case  "Friendly":
                Debug.Log("nothing" + colObj.name);
                break;
            case "Enemy":
                Debug.Log("dead" + colObj.name);
                break;
            case "Fuel":
                Debug.Log("fuel" + colObj.name);
                break;
        }
    }
}
