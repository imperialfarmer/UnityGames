using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeConfirmButton : MonoBehaviour {

    [SerializeField] string key;
    [SerializeField] int price;
	
    public void Upgrade(){
        PlayerPrefsManager.Upgrade(key, price);
    }
}
