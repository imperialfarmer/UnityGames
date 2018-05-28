using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour {

    public GameManager gameManager;
    public GameObject slider;

    private Text text;
    private string start = "Find a clear space for helicopter landing";
    private string spotLandingArea =
        "Landing area spotted";
    private string heliWaitingForLanding = 
        "Helicopter has arrived the target area, " +
        "but it is having diffulties in landing. " +
        "Make sure you can survive until pilots fix the problem!";
    private string zombieSpotYou = "Zombies spotted you!";

    private AudioSource audioSource;

    void Awake () {
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
        text = GetComponent<Text>();
        RemoveText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Info_Start()
    {
        text.text = start;
        gameManager.StartStage();
    }

    public void Info_LandingAreaSpotted(){
        text.text = spotLandingArea;
        Invoke("RemoveText", 10f);
    }

    public void Info_WaitingForLandind(){
        text.text = heliWaitingForLanding;
        Invoke("RemoveText", 10f);

        slider.SetActive(true);
        slider.GetComponent<TimeSlider>().StartTime();

        gameManager.SurviveStage();

        Invoke("Info_ZombieSpotYou",5f);
    }

    public void Info_ZombieSpotYou(){
        audioSource.Play();
        text.text = zombieSpotYou;
        gameManager.ZombieStage();
        Invoke("Info_Run", 5f);
    }

    void RemoveText(){
        text.text = "";
    }

    void Info_Run(){
        text.text = "RUN!!";
        Invoke("RemoveText", 10f);
    }
}
