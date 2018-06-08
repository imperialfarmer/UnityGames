using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    [SerializeField] int damage = 50;

    private void OnTriggerEnter(Collider collision)
    {
        GameObject colObj = collision.gameObject;
        Debug.Log(gameObject.name + " collisioned with " + colObj.name);
        if(colObj.GetComponent<Rocket>()){
            PlayerHealth playerHealth = colObj.GetComponent<PlayerHealth>();
            Rocket rocket = colObj.GetComponent<Rocket>();
            if (playerHealth.currentHealth + playerHealth.currentShield <= damage)
            {
                rocket.ReactToDeath();
            }
            else
            {
                rocket.ReactToDamage(damage);
            }
            transform.parent.GetChild(0).GetComponent<ParticleSystem>().Play();
            transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.parent.GetChild(2).gameObject.SetActive(false);
            GetComponent<MeshRenderer>().enabled = false;
            transform.parent.GetComponent<AudioSource>().Play();
            Invoke("DestroyParent", 1f);

        }
    }

    private void DestroyParent()
    {
        Destroy(transform.parent.gameObject);
    }
}
