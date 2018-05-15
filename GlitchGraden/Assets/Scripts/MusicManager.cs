using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;

	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	void Start(){
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
		audioSource.Play();
	}

	void Update () {

	}

	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log("in Level " + level);
		if(thisLevelMusic){ // if there is music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void SetVolume (float volume){
		audioSource.volume = volume;
	}
}
