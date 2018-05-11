using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private LevelManager levelManager;

	public float health = 150f;
	public float bodyExplosion = 100f;

	public GameObject enemyLaserPrefab;
	public float laserSpeed = 10f;
	public float fireFrequency = 0.5f;

	public static int countEnemy = 0;

	void Start(){
		countEnemy++;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void Update(){
		float probability = Time.deltaTime * fireFrequency;
		if(Random.value < probability){
			Fire();
		}
	}

	void Fire(){
		Vector3 startPos = transform.position + Vector3.up*-0.5f;
		GameObject enemyLaser = Instantiate(enemyLaserPrefab, startPos, Quaternion.identity) as GameObject;
		enemyLaser.GetComponents<Rigidbody2D>()[0].velocity = new Vector2(0f, -laserSpeed);
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log("Touch the enemy's Body");

		PlayerLaser playerLaser = collider.gameObject.GetComponent<PlayerLaser>();
		if(playerLaser){
			playerLaser.Hit();
			print(this.health);
			health -= playerLaser.ReturnDamage();
			print(this.health);
			if(this.health <= 0){
				Destroy(gameObject);
				countEnemy--;
				//if(countEnemy <= 0){
				//	levelManager.LoadLever("Win");
				//}
			}
		}

		PlayerController player = collider.gameObject.GetComponent<PlayerController>();
		if(player){
			Destroy(gameObject);
			player.health -= bodyExplosion;
			if(player.health <= 0){
				Destroy(collider.gameObject);
				levelManager.LoadLever("Lose");
			}
		}
	}
}
