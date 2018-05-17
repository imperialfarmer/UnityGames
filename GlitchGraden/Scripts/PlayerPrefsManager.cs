using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	// level_uplocked_1 or 2...
	public static void SetMasterVolume(float volume){
		if(volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}else{
			Debug.LogError("Volume exceeds the limit");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel (int level){
		if(level <= Application.levelCount - 1){
			PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // use 1 for true, 0 for false
		}else{
			Debug.LogError("Level is not unlocked");
		}
	}

	public static bool IsLevelUnlocked(int level){
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		if(level <= Application.levelCount - 1){
			return isLevelUnlocked;
		}else{
			Debug.LogError("Level is not unlocked");
			return false;
		}
	}

	public static void SetDifficulty (float difficulty){
		if(difficulty >= 0f && difficulty <= 1f){
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		}else{
			Debug.LogError("Difficulty out of range");
		}
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
}
