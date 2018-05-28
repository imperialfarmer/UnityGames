using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public float damage = 20f;

    private GameObject radio;

    public AudioClip attack;
    public AudioClip idle;

    private Animator animator;
    private AudioSource audioSource;
    private LevelManager levelManager;
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        radio = FindObjectOfType<RadioSystem>().gameObject;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        IdleSound();
	}
	
	void Update () {
        if (!audioSource.isPlaying) IdleSound();
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject col = collision.gameObject;
        if(col && col.GetComponent<Player>()){
            Player player = col.GetComponent<Player>();

            if (audioSource.clip == idle) AttackSound();
            if (audioSource.clip != idle && !audioSource.isPlaying) AttackSound();
                        
            animator.SetTrigger("isAttacking");
            if(player.health >= 0){
                player.health -= damage;
            }else{
                if (player.chance > 0)
                {
                    player.respawn = true;
                    player.chance -= 1;

                    Player newPlayer = radio.GetComponentInChildren<Player>();
                    GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target =
                        player.transform;
                }
                else{
                    levelManager.LoadLever("_Lose");
                }
            }
        }
    }

    public void IdleSound()
    {
        audioSource.clip = idle;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void AttackSound(){
        audioSource.clip = attack;
        audioSource.loop = false;
        audioSource.Play();
    }


}
