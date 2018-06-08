using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {
    [SerializeField] Vector3 windForce;

    private void OnTriggerStay(Collider other)
    {
        GameObject triObj = other.gameObject;
        if(triObj.tag == "Friendly"){
            if(triObj.GetComponent<Rigidbody>()) 
                triObj.GetComponent<Rigidbody>().AddForce(windForce);
        }
        if (triObj.tag == "Pointer")
        {
            if (triObj.GetComponent<Rigidbody>())
                triObj.GetComponent<Rigidbody>().AddForce(windForce*1.5f);
        }
    }
}
