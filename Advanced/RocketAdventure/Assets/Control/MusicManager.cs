using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MusicManager : MonoBehaviour
{

    public AudioClip[] PlayList;

    static MusicManager instance = null;
    static bool justStarted = false;
    static int currenLevel = 0;
    private enum State {MENU, W0, W1, W2, W3, W4, W5, CAST};
    static State state;
    static int playIndex;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            justStarted = false;
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            justStarted = true;
            state = State.MENU;
            playIndex = 0;
        }
    }

    void Start(){
        //audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        if (currenLevel == 0 && justStarted)
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                AudioClip thisLevelMusic = PlayList[0];
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = thisLevelMusic;
                GetComponent<AudioSource>().Play();
            }
        }
	}

	void Update () {
	}

    void OnLevelWasLoaded(int level)
    {

        SetState(level);
        justStarted = false;
        PlayMusic();
	}

	//public void SetVolume (float volume){
	//	audioSource.volume = volume;
	//}

    void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    void SetState(int level){
        if (level >= 0 && level <= 2) { state = State.MENU; playIndex = 0; }
        else if (level >= 3 && level <= 8) { state = State.W0; playIndex = 1; }
        else if (level >= 9 && level <= 14) { state = State.W1; playIndex = 2; }
        else if (level >= 15 && level <= 20) { state = State.W2; playIndex = 3; }
        else if (level >= 21 && level <= 26) { state = State.W3; playIndex = 4; }
        else if (level >= 27 && level <= 32) { state = State.W4; playIndex = 5; }
        else if (level >= 33 && level <= 38) { state = State.W5; playIndex = 6; }
        else { state = State.CAST; playIndex = 7; }
        Debug.Log("Now it's " + state);
    }

    void PlayMusic(){
        if (state == State.MENU)
        {
            if (GetComponent<AudioSource>().clip == PlayList[0])
            {
                return;
            }
            else
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = PlayList[playIndex];
                GetComponent<AudioSource>().Play();
            }
        }
        if (state == State.W0)
        {
            if (GetComponent<AudioSource>().clip == PlayList[1])
            {
                return;
            }
            else
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = PlayList[playIndex];
                GetComponent<AudioSource>().Play();
            }
        }
        if (state == State.W1)
        {
            if (GetComponent<AudioSource>().clip == PlayList[2])
            {
                return;
            }
            else
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = PlayList[playIndex];
                GetComponent<AudioSource>().Play();
            }
        }
        if (state == State.W2)
        {
            if (GetComponent<AudioSource>().clip == PlayList[3])
            {
                return;
            }
            else
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = PlayList[playIndex];
                GetComponent<AudioSource>().Play();
            }
        }
        if (state == State.W3)
        {
            if (GetComponent<AudioSource>().clip == PlayList[4])
            {
                return;
            }
            else
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = PlayList[playIndex];
                GetComponent<AudioSource>().Play();
            }
        }
        if (state == State.W4)
        {
            if (GetComponent<AudioSource>().clip == PlayList[5])
            {
                return;
            }
            else
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = PlayList[playIndex];
                GetComponent<AudioSource>().Play();
            }
        }
        if (state == State.W5)
        {
            if (GetComponent<AudioSource>().clip == PlayList[6])
            {
                return;
            }
            else
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = PlayList[playIndex];
                GetComponent<AudioSource>().Play();
            }
        }
        if (state == State.CAST)
        {
            if (GetComponent<AudioSource>().clip == PlayList[7])
            {
                return;
            }
            else
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = PlayList[playIndex];
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
