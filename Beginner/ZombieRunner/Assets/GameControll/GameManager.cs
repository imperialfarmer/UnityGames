using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager:MonoBehaviour{

    public MusicManager musicManager;
    public GameObject enemyRespawnParent;
    //public LevelManager levelManager;

    public void StartStage(){

        Debug.LogWarning("Game Starts");
        musicManager.playStartMusic();
    }

    public void SurviveStage()
    {
        Debug.LogWarning("Game Survive");
    }

    // TODO zombie appear

    public void ZombieStage(){
        Debug.LogWarning("Zombie Time");
        musicManager.playZombieMusic();
        enemyRespawnParent.SetActive(true);
    }

    // TODO manage game scenes trasiant
}
