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

	public int scoreValue = 150;
	private ScoreKeeper scoreKeeper;

	public AudioClip fireSound;
	public AudioClip deathSound;

	public AudioClip explosionSound;

	private HealthText healthText;
	private ChanceText chanceText;

	public GameObject smoke;

	void Start(){
		countEnemy++;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		healthText = GameObject.Find("HealthText").GetComponent<HealthText>();
		chanceText = GameObject.Find("ChanceText").GetComponent<ChanceText>();
		// 'ScoreBoard' is the name of GameObject in Unity, which is the object of that text
		scoreKeeper = GameObject.Find("ScoreBoard").GetComponent<ScoreKeeper>();
		// scoreKeeper.Reset();
	}

	void Update(){
		float probability = Time.deltaTime * fireFrequency;
		if(Random.value < probability){
			Fire();
		}
	}

	void Fire(){
		GameObject enemyLaser = Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity) as GameObject;
		enemyLaser.GetComponents<Rigidbody2D>()[0].velocity = new Vector2(0f, -laserSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log("Touch the enemy's Body");

		PlayerLaser playerLaser = collider.gameObject.GetComponent<PlayerLaser>();
		if(playerLaser){
			GenerateSmoke();
			playerLaser.Hit();
			print(this.health);
			health -= playerLaser.ReturnDamage();
			print(this.health);
			if(this.health <= 0){
				Destroy(gameObject);
				AudioSource.PlayClipAtPoint(deathSound, transform.position);
				scoreKeeper.Score(scoreValue);
				countEnemy--;
				//if(countEnemy <= 0){
				//	levelManager.LoadLever("Win");
				//}
			}
		}

		PlayerController player = collider.gameObject.GetComponent<PlayerController>();
		if(player){
			Destroy(gameObject);
			GenerateSmoke();
			AudioSource.PlayClipAtPoint(deathSound, transform.position);
			scoreKeeper.Score(scoreValue);
			float damage = bodyExplosion;
			healthText.ShowHealth(player.health);
			player.Damaged(damage);
		}
	}

	void GenerateSmoke(){
		Vector3 smokePos = transform.position;
		// a game object is instantiated using this way:
		// the object, the position, the rotation
		GameObject smokepuff 
			= Instantiate(smoke, smokePos, Quaternion.identity) as GameObject;
		smokepuff.GetComponent<ParticleSystem>().startColor 
			= gameObject.GetComponent<SpriteRenderer>().color;
		AudioSource.PlayClipAtPoint(explosionSound, transform.position);
	}
}
