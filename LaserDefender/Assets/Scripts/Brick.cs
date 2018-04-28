using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {


	public AudioClip crack;
	public static int breakableCount = 0;
	public Sprite[] hitSprites; // cen be set using GUI
	public GameObject smoke; 

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		isBreakable = (this.tag == "Breakable");
		// keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
			print(breakableCount);
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col){
		// can set bricks to be tagged in different tags
		if(isBreakable){
			HandleHits();
			AudioSource.PlayClipAtPoint(crack, transform.position,1f);
		}
	}

	void HandleHits(){
		timesHit ++;
		int maxHits = hitSprites.Length + 1; 
		if(timesHit >= maxHits){
			generateSmoke();
			Destroy(gameObject);
			breakableCount--;
			levelManager.BrickDestoyed();
			//print(breakableCount);
		}
		else{
			LoadSprites();

		}
	}

	void LoadSprites(){
		int spriteIndex =  timesHit - 1;
		// load sprite renderer to render which sprite
		// pass sprite array to renderer
		// hitSprites[spriteIndex] returns false if there is no
		// sprite assigned to the array
		if(hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else{
			Debug.LogError("Sprite Texture MISSING!");
		}
	}

	void generateSmoke(){
		Vector3 smokePos = gameObject.transform.position;
		// a game object is instantiated using this way:
		// the object, the position, the rotation
		GameObject smokepuff 
			= Instantiate(smoke, smokePos, Quaternion.identity) as GameObject;
		smokepuff.GetComponent<ParticleSystem>().startColor 
			= gameObject.GetComponent<SpriteRenderer>().color;
	}
}
