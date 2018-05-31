using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation : MonoBehaviour {

	// here is to spawn enemy from prefab
	// there will be no object "enemy" in the scene
	// so declared and set enemy to this object in gui as public is better
	public GameObject enemyPrefab;
	public float width;
	public float height;
	public float speed = 5;
	public float spawnDelay = 0.5f;

	// the switch of moving direction of enemies
	private int movingRight = 1, movingUp = 1;
	private int movingLeft = 0, movingDown = 0;

	// the edge of enemy sprite
	private float xMax, xMin, yMin, yMax;
	// the center of the fomulation
	public float startX, startY;

	// Use this for initialization
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 lowerBound = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distanceToCamera));
		Vector3 upperBound = Camera.main.ViewportToWorldPoint(new Vector3(1,1,distanceToCamera));

		xMin = lowerBound.x-startX; xMax = upperBound.x-startX;
		yMin = lowerBound.y-startY; yMax = upperBound.y-startY;

		SpawnUntilFull();
	}

	// this is just to show the bounding box of the formation
	public void OnDrawGizmos (){
		Gizmos.DrawWireCube(new Vector3(transform.position.x+startX,transform.position.y+startY, transform.position.z),
		                    new Vector3(width,height));
	}
	
	// Update is called once per frame
	void Update (){
		
		// here is to move object EnemySpawn
		// the position of 'position' relative to EnemySpawn remain the same
		// the movement is moved 
		transform.position
			+= new Vector3(speed*Time.deltaTime*movingRight - speed*Time.deltaTime*movingLeft, 
						   speed*Time.deltaTime*movingUp - speed*Time.deltaTime*movingDown);

		float rightEdgeOfFormation = transform.position.x + 0.5f*width,
			  leftEdgeOfFormation = transform.position.x - 0.5f*width,
			  upEdgeOfFormation = transform.position.y + 0.5f*height,
			  downEdgeOfFormation = transform.position.y - 0.5f*height;

		// if formation touched the edge, flip the direction
		if(leftEdgeOfFormation < xMin) {movingRight = 1; movingLeft = 0;}; 
		if(rightEdgeOfFormation > xMax) {movingRight = 0; movingLeft = 1;};
		if(downEdgeOfFormation < yMin) {movingUp = 1; movingDown = 0;}; 
		if(upEdgeOfFormation > yMax) {movingUp = 0; movingDown = 1;}; 

		if( AllMembersDead() ){
			Debug.Log("Empty Formation");
			SpawnUntilFull();
		}
	}

	void SpawnEnemies(){
		foreach(Transform child in transform){
			GameObject enemy 
				= Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			// the enemy is attached to this Object (.child) 
			// or become the parent of other objects (.parent)
			// this is to keep the hierarchy
			// the child of formation is 'position'
			// the parent of enemy is 'position'
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull(){
		Transform emptyPos = NextFreePosition();
		if(emptyPos){
			GameObject enemy 
				= Instantiate(enemyPrefab, emptyPos.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = emptyPos;
		}
		// there will be a bug
		// in Start() if the enemy is destroied, it will respawn until full
		if(NextFreePosition()){
			Invoke("SpawnUntilFull", spawnDelay);
		}
	}

	Transform NextFreePosition(){
		foreach(Transform childPositionGameObject in transform){
			if( childPositionGameObject.childCount == 0 ){
				return childPositionGameObject;
			}
		}
		return null;
	}

	bool AllMembersDead(){
		foreach(Transform childPositionGameObject in transform){
			if(childPositionGameObject.childCount > 0 ){
				return false;
			}
		}
		return true;
	}
}
