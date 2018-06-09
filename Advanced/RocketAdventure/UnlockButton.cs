using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockButton : MonoBehaviour {
    
    public void UnlockAllLevels(){
        PlayerPrefsManager.UnlockAllLevels();
    }
}
