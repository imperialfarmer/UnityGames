using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLever(string name){
        SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Application.Quit();
	}
}
