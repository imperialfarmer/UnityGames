using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSetter : MonoBehaviour {

    public bool ballIsIn = false;
    public bool pinSettled = false;
    private float raiseDistance = 40f;
    private float raiseOffset = 5f;
    private float lastChangeTime;
    private int lastStandingCount = -1;

    public GameObject pinSet;

    private Ball ball;

	// Use this for initialization
	void Start () {
        //print(CountStanding());
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        //print(CountStanding());
        if(ballIsIn) ChcekStanding();
	}

    public int CountStanding(){
        int standing = 0;
        foreach (Pin pin in FindObjectsOfType<Pin>())
		{
            if(pin.isStanding()){
                standing++;
                //print(pin.name);
            }else{
                //print(pin.name);
            }
		}
        return standing;
    }

    private void OnTriggerEnter(Collider col)
    {
        GameObject thingHit = col.gameObject;
        if (thingHit.GetComponent<Ball>())
        {
            ballIsIn = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        GameObject thingLeft = col.gameObject;
        if (thingLeft.GetComponentInParent<Pin>()) {
            // print(thingLeft.GetComponentInParent<Pin>());
            Destroy(thingLeft.transform.parent.gameObject);
        }
    }

    private void ChcekStanding(){
        // Update the lastStandingCount
        int currentStanding = CountStanding();
        if(currentStanding != lastStandingCount){
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }
        float settleTime = 3f; 
        if((Time.time - lastChangeTime) > settleTime){
            PinsHaveSettled();
        }
    }

    private void PinsHaveSettled(){
        lastStandingCount = -1; // pins have settled, and ball not back
        ballIsIn = false;
        pinSettled = true;
        ball.Reset();
    }

    public void renewPins(){
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            Destroy(pin.transform.gameObject);
            Destroy(pin.transform.parent.gameObject);
        }
        GameObject pins = 
            Instantiate(pinSet, new Vector3(0, 40, 1829), Quaternion.identity) as GameObject;
        foreach (Pin pin in FindObjectsOfType<Pin>()){
            pin.GetComponent<Rigidbody>().useGravity = false;
        }

    }

    public void raisePins(){
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.isStanding() )
            {
                pin.GetComponent<Rigidbody>().velocity = Vector3.zero;
                pin.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                pin.GetComponent<Rigidbody>().useGravity = false;

                pin.transform.Translate(Vector3.up * raiseOffset);
                //print(pin.transform.position);
            }
        }
    }

    public void lowerPins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.isStanding())
            {
                pin.GetComponent<Rigidbody>().velocity = Vector3.zero;
                pin.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                pin.GetComponent<Rigidbody>().useGravity = false;

                pin.transform.Translate(Vector3.down * raiseOffset);
                //print(pin.transform.position);
            }
        }
    }

    public void tidyFinished(){
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.isStanding())
            {
                pin.GetComponent<Rigidbody>().velocity = Vector3.zero;
                pin.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                pin.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}
