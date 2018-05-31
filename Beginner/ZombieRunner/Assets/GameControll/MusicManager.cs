using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager:MonoBehaviour{
    
    public AudioClip startMusic;
    public AudioClip surviveMusic;

    private AudioSource audioSource;

    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }
	
    public void playStartMusic(){
        audioSource.clip = startMusic;
        if (!audioSource.clip) Debug.LogError("Start Music Clip not Found!");
        audioSource.Play();
    }

    public void playZombieMusic()
    {
        audioSource.clip = surviveMusic;
        audioSource.Play();
    }
}
