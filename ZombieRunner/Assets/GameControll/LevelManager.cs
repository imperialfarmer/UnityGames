using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	void Awake(){
	}

	void Start(){
	}

	public void LoadLever(string name){
		Application.LoadLevel(name);
	}

	public void QuitRequest(){
		Application.Quit();
	}

	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
