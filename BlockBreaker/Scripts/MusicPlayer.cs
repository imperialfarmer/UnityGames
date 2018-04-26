using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	void Awake(){
	Debug.Log("MusicPlayer Awake" + GetInstanceID());
	if (instance != null){
		Destroy(gameObject);
		//Debug.Log("Duplicate Music Player is destructed!");
	}
	else{
		// we are defining the gameObject here
		// "this" means the class MusicPlayer we are defining now
		instance = this;
		// this gameObject is the object which has this code
		// the GameObject can go through different scenes
		GameObject.DontDestroyOnLoad(gameObject); 
	}
	}

	// Use this for initialization
	void Start () {
		//Debug.Log("MusicPlayer Start" + GetInstanceID());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
