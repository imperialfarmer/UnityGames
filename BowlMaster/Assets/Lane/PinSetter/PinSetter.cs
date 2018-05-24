using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSetter : MonoBehaviour {

    public bool ballOutOfPlay = false;
    public bool pinSettled = false;
    public int lastSettledCount = 10;
    public bool isSwiping = false;

    private float raiseDistance = 40f;
    private float raiseOffset = 5f;
    private float lastChangeTime;
    private int lastStandingCount = -1;

    private Animator animator;

    private ActionMaster actionMaster = new ActionMaster();

    public GameObject pinSet;

    private Ball ball;

	void Start () {
        ball = FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        //print(CountStanding());
        if(ballOutOfPlay) ChcekStanding();
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
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;
        // TODO:  connect ActionMaster to PinSetter
        // print(actionMaster.Bowl(pinFall));

        ActionMaster.Action action = actionMaster.Bowl(pinFall);

        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("End Game?");
            lastSettledCount = 10;
        }
        else throw new UnityException("Action not recognized");

        lastStandingCount = -1; // pins have settled, and ball not back
        ballOutOfPlay = false;
        pinSettled = true;
        ball.Reset();
    }

    public void renewPins(){
        isSwiping = true;
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
        isSwiping = true;
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
        // TODO remove all not standing pins
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
        isSwiping = false;
    }

    public void IsSwiping(){
        isSwiping = true;
    }
    public void FinishSwiping()
    {
        isSwiping = true;
    }
}
