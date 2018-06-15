using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
// lead the game to the right scene
	public void LoadLever(string name){
		Debug.Log("Lever request for : " + name);
		// jump to the scene which has been input in gui
		// "Game" is given, so the after click this button
		// the game will start the scene "Game" 
		Application.LoadLevel(name);
	}

	public void QuitRequest(){
		Debug.Log("I wanna quit!");
		Application.Quit();
	}
}
