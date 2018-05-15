using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
// lead the game to the right scene
	private static int currentLevel = 3;
	private static bool hasStarted = false;
	public float autoLoadNextLevelAfter;

	void Awake(){
		if (Application.levelCount <= 7){
			Debug.Log("Now loading " + Application.levelCount);
			hasStarted = true;
		}
	}

	void Start(){
		if (!hasStarted){
			Debug.Log("Now loading " + Application.levelCount);
			if(autoLoadNextLevelAfter <= 0f){
			}else{
				Invoke("LoadNextLevel", autoLoadNextLevelAfter);
			}
		}
	}
	public void LoadLever(string name){
		//Debug.Log("Lever request for : " + name);
		// jump to the scene which has been input in gui
		// "Game" is given, so the after click this button
		// the game will start the scene "Game" 
		Application.LoadLevel(name);
	}

	public void QuitRequest(){
		Application.Quit();
	}

	public void LoadNextLevel(){
		// automatically load the next level
		//Brick.breakableCount = 0;
		currentLevel++;
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void loadCurrentLevel(){
		Application.LoadLevel(currentLevel);
	}

	public void BrickDestoyed(){
		// if this is the last brick, then load next level
		//if(Brick.breakableCount <= 0){
		//	LoadNextLevel();
		//}
	}
}
