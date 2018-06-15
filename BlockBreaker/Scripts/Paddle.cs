using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autoPlay;
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay){
			MoveWithMouse();
		}
		else{
			AutoPlay();
		}
	}

	void MoveWithMouse(){
		// mouse coordinate is read within the resolution
		// normalize the coordinate
		// *16 = game unit
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16 - 8;
		//Debug.Log(mousePosInBlocks);

		// this.transform.position is a 'Vector3'
		Vector3 paddlePos = new Vector3(Input.mousePosition.x, -5f, 0f);
		paddlePos.x = mousePosInBlocks;
		// the x will be clamped from -7.5~7.5, current position is
		// mousePosInBlocks
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, -7.2f, 7.2f);
		this.transform.position = paddlePos;
	}

	void AutoPlay(){
		Vector3 paddlePos = new Vector3(ball.transform.position.x, this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}
}
