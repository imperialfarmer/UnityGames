using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRespawn : MonoBehaviour {
    
    public GameObject player, zombiePrefab;
    public float radius = 500f;
    public int zombieNamePostfix = 0;
    public int maxZombies, minZombies;
    public float intervalTime = 20f;
    private float lastRepawningTime = 0f;
    Vector3 SpawnPos = new Vector3(0, 0, 0);

    private void SpawnMethod()
    {
        bool areaIsOnMap = false;
        while (!areaIsOnMap)
        {
            float playerX = player.transform.position.x;
            float playerZ = player.transform.position.z;
            SpawnPos.x = Random.Range(playerX - radius, playerX + radius);
            SpawnPos.z = Random.Range(playerZ - radius, playerZ + radius);
            SpawnPos.y = Terrain.activeTerrain.SampleHeight(SpawnPos) + 0.5f;
            NavMeshHit hit;
            areaIsOnMap = (NavMesh.SamplePosition(SpawnPos, out hit, 10f, NavMesh.AllAreas));
            print(areaIsOnMap);
        }

        GameObject zombie = Instantiate(zombiePrefab, SpawnPos, Quaternion.identity) as GameObject;
        zombie.transform.parent = transform;
        zombie.name += zombieNamePostfix;
        print(SpawnPos.ToString() + areaIsOnMap.ToString() + zombie.name);
        zombieNamePostfix++;
        zombie.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = 
            player.transform;
    }

    public void ZombieSpawn(){
        int counter = 0;
        int zombiesToSpawn =
            Random.Range(minZombies, maxZombies);
        while (counter <= zombiesToSpawn)
        {
            counter++;
            SpawnMethod();
        }
    }

    void Update()
    {
        if(Time.time - lastRepawningTime >= intervalTime){
            lastRepawningTime = Time.time;
            ZombieSpawn();
        }
    }
}
