using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager{

	const string LEVEL_KEY = "level_unlocked_";

    public static void UnlockLevel(int level)
    {
        Debug.Log("Try to unlock " + level.ToString());
        if (level - 3 >= PlayerPrefs.GetInt(LEVEL_KEY))
        {
            PlayerPrefs.SetInt(LEVEL_KEY, level - 3);
            Debug.Log("Level " + (level - 3).ToString() + " Unlocked");
        }

        //PlayerPrefs.SetInt(LEVEL_KEY, 0);
    }

    public static int GetUnlockLevel(){
        return PlayerPrefs.GetInt(LEVEL_KEY);
    }
}
