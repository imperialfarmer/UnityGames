using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 3f;

    private AudioSource audioSource;


	// Use this for initialization
	void Start () {
        //print(name + " " + isStanding());
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public bool isStanding(){
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        //print(name + " " + rotationInEuler);
        float tiltInX = 
            Mathf.Abs(rotationInEuler.x) > Mathf.Abs(rotationInEuler.x - 360f) ?
            Mathf.Abs(rotationInEuler.x - 360f) : Mathf.Abs(rotationInEuler.x);
        float tiltInZ = 
            Mathf.Abs(rotationInEuler.z) > Mathf.Abs(rotationInEuler.z - 360f) ?
            Mathf.Abs(rotationInEuler.z - 360f) : Mathf.Abs(rotationInEuler.z);

        if (tiltInX <= standingThreshold &&
           tiltInZ <= standingThreshold)
        {
            transform.rotation = Quaternion.identity;
            return true;
        }
        else
        {
            return false;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        GameObject col = collision.gameObject;
        //Debug.Log(name + " collised with" + col);
        if (col.GetComponent<Ball>()) audioSource.Play();
    }

}
