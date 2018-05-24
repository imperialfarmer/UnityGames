using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    private Ball ball;
    private PinSetter pinSetter;

    private float startTime = 0f, endTime = 0f;
    private Vector3 dragStart, dragEnd;
    private float factor1 = 2f;
    private float factor2 = 1f;
    private float maxX = 1000f;
    private float maxZ = 1000f;
	void Start () {
        ball = GetComponent<Ball>();
        pinSetter = FindObjectOfType<PinSetter>();
	}
	
	void Update () {
		
	}

    public void DragStart(){
        //ball = Instantiate(Ball,);
        if(!ball.inPlay && !pinSetter.ballOutOfPlay && !pinSetter.isSwiping){
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }

    public void DragEnd(){
        if (!ball.inPlay && !pinSetter.ballOutOfPlay && !pinSetter.isSwiping)
        {
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float dragDuration = endTime - startTime;

            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

            //print("dragStart = " + dragStart);
            //print("startTime = " + startTime);
            //print("dragEnd = " + dragEnd);
            //print("endTime = " + endTime);

            //launchSpeedX = (launchSpeedX >= 100)

            Vector3 launchVelocity =
                new Vector3(launchSpeedX / factor1, 0f, launchSpeedZ / factor2);
            //print("Launch velosity = " + launchVelocity);
            ball.Launch(launchVelocity);
            ball.inPlay = true;
        }
    }
}
