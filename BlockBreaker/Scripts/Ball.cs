using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	public AudioClip bounce;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		//Debug.Log(paddleToBallVector.y);
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			// the ball has to be excuted after the paddle
			// otherwise the position of ball can not be attached 
			// to the paddle
			// edit -> project setting -> execution order
			// lock the ball relatively to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			// GetMouseButton(0) = left, (1) = right, (2) = middle
			// Down = only one click
			// wait a mouse press to launch
			if(Input.GetMouseButtonDown(0)){
				//Debug.Log("Left Mouse Clicked, Launch Ball");
				AudioSource.PlayClipAtPoint(bounce, transform.position, 0.35f);
				float randomX = Random.Range(-4f,4f),
					  randomY = Random.Range(20f,20.5f);
				this.GetComponent<Rigidbody2D>().velocity 
					= new Vector2 (randomX, randomY);
				hasStarted = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
 		Vector2 tweak = new Vector2 (Random.Range(-4f, 4f), Random.Range(0f, 2f));
		if(hasStarted){
			AudioSource.PlayClipAtPoint(bounce, transform.position, 0.35f);
			this.GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
