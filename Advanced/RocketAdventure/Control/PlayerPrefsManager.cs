using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager{

    // level code
	const string LEVEL_KEY = "level_unlocked_";

    // upgrade codes
    const string UP0 = "upgrade_0_"; // shiled 1
    const string UP1 = "upgrade_1_"; // shiled 2
    const string UP2 = "upgrade_2_"; // health 1
    const string UP3 = "upgrade_3_"; // health 2

    // total number rainbow materials
    const string MAT_OBTAINED = "material_obtained_";

    // hidden rainbow materials
    const string MAT_0 = "material_0_";
    const string MAT_1 = "material_1_";
    const string MAT_2 = "material_2_";
    const string MAT_3 = "material_3_";
    const string MAT_4 = "material_4_";
    const string MAT_5 = "material_5_";
    const string MAT_6 = "material_6_";
    const string MAT_7 = "material_7_";

    // resolution codes
    const string RES_0 = "res_0_"; // 5:4
    const string RES_1 = "res_1_"; // 4:3
    const string RES_2 = "res_2_"; // 3:2
    const string RES_3 = "res_3_"; // 16:10
    const string RES_4 = "res_4_"; // 16:9

    public static void UnlockLevel(int level)
    {
        Debug.Log("Try to unlock " + level.ToString());
        if (level - 3 >= PlayerPrefs.GetInt(LEVEL_KEY))
        {
            PlayerPrefs.SetInt(LEVEL_KEY, level - 3);
            Debug.Log("Level " + (level - 3).ToString() + " Unlocked");
        }
    }

    public static int GetUnlockLevel(){
        return PlayerPrefs.GetInt(LEVEL_KEY);
    }

    public static void ResetLevels()
    {
        PlayerPrefs.SetInt(LEVEL_KEY, 0);
        PlayerPrefs.SetInt(MAT_OBTAINED, 0);
        for (int i = 0; i < 8; i++){
            string mat = "material_" + i + "_";
            PlayerPrefs.SetInt(mat, 0);
        }
        for (int i = 0; i < 4; i++)
        {
            string upgrade = "upgrade_" + i + "_";
            PlayerPrefs.SetInt(upgrade, 0);
        }
    }

    public static void UnlockAllLevels()
    {
        PlayerPrefs.SetInt(LEVEL_KEY, 40);
    }

    public static void MaterialObtained(int index){
        int currenMat = PlayerPrefs.GetInt(MAT_OBTAINED);
        PlayerPrefs.SetInt(MAT_OBTAINED, currenMat + 1);
        //Debug.Log
        //     ("MAT " + index.ToString() + " Obtained, current mat = " + currenMat.ToString());
        string mat = "material_" + index + "_";
        //Debug.Log(mat + " to be set obtained");
        PlayerPrefs.SetInt(mat, 1);
        //Debug.Log("MAT = " + PlayerPrefs.GetInt(mat));

        // TODO set all materials
    }

    public static int GiveMaterial(){
        return PlayerPrefs.GetInt(MAT_OBTAINED);
    }

    public static bool CheckMatInThisLevel(string key){
        // key here is material_*_
        if(PlayerPrefs.GetInt(key) == 1){
            return true;
        }else{
            return false;
        }
    }

    public static void Upgrade(string key, int price){
        PlayerPrefs.SetInt(key, 1);
        int currenMat = PlayerPrefs.GetInt(MAT_OBTAINED);
        PlayerPrefs.SetInt(MAT_OBTAINED, currenMat - price);
    }

    public static bool CheckUpgrade(string key){
        // key here is upgrade_*_
        if (PlayerPrefs.GetInt(key) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void SetResolution (string key, int code){
        PlayerPrefs.SetInt(key, code);
    }

    public static bool CheckResolution(string key)
    {
        // key here is res_*_
        if (PlayerPrefs.GetInt(key) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
