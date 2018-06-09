using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZone : MonoBehaviour {

    [SerializeField] int damage = 5;
    [SerializeField] float interval = 2f;

    private float currentTime = 0f;
    private float lastTimeBurned = 0f;

	void Start () {
        currentTime = Time.timeSinceLevelLoad;
	}
	
	void Update () {
        currentTime = Time.timeSinceLevelLoad;
	}

    private void OnTriggerStay(Collider other)
    {
        GameObject obj = other.gameObject;
        if(obj.tag == "Friendly"){
            Debug.Log(obj.name + " is in lavazone");
            PlayerHealth playerHealth = obj.GetComponent<PlayerHealth>();

            if(currentTime - lastTimeBurned >= interval){
                playerHealth.TakeContinuosDamage(damage);
                BurnRocket();
            }
        }
    }

    private void BurnRocket(){
        lastTimeBurned = Time.timeSinceLevelLoad;
    }
}
