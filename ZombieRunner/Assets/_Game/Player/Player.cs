using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float health = 100f;
    public int chance = 2;

    private PlayerSpawnPoints spawnPoints;
    public bool respawn = false;
    public LandingArea landingAreaPrefab;
    public Vector3 landingPos;

    private Transform[] spawnPoses;
    private bool lastRespawnToggle = false;

    private LevelManager levelManager;



	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        spawnPoints = FindObjectOfType<PlayerSpawnPoints>();
        spawnPoses = 
            spawnPoints.GetComponentsInChildren<Transform>();
        if(respawn) ReSpawn();
	}
	
	// Update is called once per frame
	void Update () {
        if (lastRespawnToggle != respawn)
        {
            ReSpawn();
            respawn = false;
        }else{
            lastRespawnToggle = respawn;
        }
	}

    private void ReSpawn(){
        int posIndex = Random.Range(1, spawnPoses.Length);
        //Debug.Log("Now Pick up pos " + posIndex);
        transform.position = spawnPoses[posIndex].position;
        health = 100f;
        //Debug.Log("Pos = " + transform.position);
    }

    void OnFindClearArea(){
        Debug.Log(name + " OnFindClearArea");
        landingPos = transform.position + Vector3.forward*1f;
        Invoke("DropFlare", 4f);
    }

    void DropFlare(){
        Instantiate
        (landingAreaPrefab, transform.position, transform.rotation);
    }
}
