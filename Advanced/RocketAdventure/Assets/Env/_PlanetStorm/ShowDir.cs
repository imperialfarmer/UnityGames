using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDir : MonoBehaviour {

    private Vector3 originalPos;
    private bool triggered = false;
    private ParticleSystem explosion;

	void Start () {
        originalPos = transform.position;
        explosion = transform.GetChild(0).GetComponent<ParticleSystem>();
	}

    private void Update()
    {
        transform.eulerAngles += Vector3.forward * Time.deltaTime * 200f * Random.Range(0f,1f);
    }

    private void Reset()
    {
        transform.position = originalPos;
        GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject colObj = other.gameObject;
        if(colObj.tag == "ThunderBorder"){
            if(triggered){
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                explosion.Play();
                GetComponent<MeshRenderer>().enabled = false;
                Invoke("Reset", Random.Range(1f,3f));
                triggered = false;
            }else{
                triggered = true;
            }
        }
    }
}
