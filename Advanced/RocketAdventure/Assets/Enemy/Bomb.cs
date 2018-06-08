using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    [SerializeField] float timeToArrive;

    private Vector3 Pos;

    private void Start()
    {
        Pos = transform.position;
    }

    void Update () {
        transform.eulerAngles += Vector3.up * Time.deltaTime * 200f * Random.Range(0f, 1f);
	}

    private void OnTriggerEnter(Collider other)
    {
        GameObject colObj = other.gameObject;
        if(colObj.GetComponent<Rocket>()){
            Debug.Log("detect " + colObj.name);
            GetComponent<Collider>().enabled = false;
            Vector3 dist = colObj.transform.position - Pos;
            Vector3 speed = dist / timeToArrive;
            //print(colObj.transform.position);
            //print(Pos);
            //print(dist);
            //print(speed);
            GetComponent<Rigidbody>().velocity = speed;
            //print(GetComponent<Rigidbody>().velocity);
            Invoke("Explosion", timeToArrive);
        }
    }

    private void Explosion(){
        transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(2).gameObject.SetActive(false);
        transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        GetComponent<AudioSource>().Play();
        Invoke("Destroy", 1f);
    }

    private void Destroy(){
        Destroy(gameObject);
    }
}
