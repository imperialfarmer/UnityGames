using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour {

    public float levelSeconds;

    private Slider slider;
    private float startTime;
    private LevelManager levelManager;

	void Start () {
        slider = GetComponent<Slider>();
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
        float timeLeft = (Time.time - startTime) / levelSeconds;
        slider.value = timeLeft;
        print("TimeSlider1 = " + timeLeft.ToString());
        print("TimeSlider2 = " + slider.value.ToString());

        bool timeIsUp = ((Time.time - startTime) >= levelSeconds);
        if (timeIsUp)
        {
            // levelManager.LoadNextLevel(); // TODO change to fuel

        }
	}

    public void StartTime(){
        slider = GetComponent<Slider>();
        startTime = Time.time;
        gameObject.SetActive(true);
    }
}
