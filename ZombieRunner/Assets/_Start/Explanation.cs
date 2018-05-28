using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explanation : MonoBehaviour {

    private bool show = false;
	void Start () {
        gameObject.SetActive(show);
	}

    public void changeShow(){
        show = !show;
        gameObject.SetActive(show);
    }
}
