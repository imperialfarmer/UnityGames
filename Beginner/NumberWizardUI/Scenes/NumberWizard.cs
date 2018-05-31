using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

	int max, min, guess;
	public int maxGuessesAllowed = 10;
	public Text text;

	// Use this for initialization
	// only launch at the start scene or first frame
	void Start () {
		StartGame();
	}

	void StartGame () {
		max = 1000;
		min = 1;
		max += 1;
		NextGuess();
	}

	public void GuessHigher(){
		Debug.Log("Guess is higher ...");
		max = guess;
		NextGuess();
	}

	public void GuessLower(){
		Debug.Log("Guess is lower ...");
		min = guess;
		NextGuess();
	}

	void NextGuess () {
		guess = Random.Range(min, max);
		// guess = (max + min)/2;
		Debug.Log("Higher or lower than " + guess);
		text.text = guess.ToString();
		maxGuessesAllowed -= 1;
		if(maxGuessesAllowed <= 0){
			Application.LoadLevel("Win");
		}
	}
}
