using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    [SerializeField] float thrustPowerPerFrame = 50f;
    [SerializeField] float rotatePowerPerFrame = 300f;
    [SerializeField] float transitionTime = 1f;

    public static int currentLevel = 1;
    [SerializeField] int damage = 25;

    [SerializeField] ParticleSystem enginePS;
    [SerializeField] ParticleSystem successPS;
    [SerializeField] ParticleSystem damagedPS;
    [SerializeField] ParticleSystem deathPS1;
    [SerializeField] ParticleSystem deathPS2;
    [SerializeField] AudioClip collisionSound;
    [SerializeField] AudioClip deadSound;
    [SerializeField] AudioClip engineSound;
    [SerializeField] AudioClip powerUpSound;
    [SerializeField] AudioClip finishSound;

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private enum State { Transcending, Alive, Dying, Damaging };
    private State state = State.Alive;
    private PlayerHealth playerHealth;

	void Start () {
        audioSource1 = GetComponents<AudioSource>()[0];
        audioSource2 = GetComponents<AudioSource>()[1];
        playerHealth = GetComponent<PlayerHealth>();
	}
	
	void Update () {
        if (playerHealth.currentHealth < 100) deathPS2.Play();
        else deathPS2.Stop();

        if (state == State.Alive || state == State.Damaging)
        {
            Thrust();
            Rotate();
        }
	}

    private void Thrust(){
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddRelativeForce
                     (Vector3.up * thrustPowerPerFrame);
            if (!audioSource1.isPlaying) audioSource2.PlayOneShot(engineSound);
            enginePS.Play();
        } else
        {
            audioSource2.Stop();
            enginePS.Stop();
        }
    }

    private void Rotate(){
        //rigidbody.freezeRotation = true;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate
                     (Vector3.back * rotatePowerPerFrame * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate
                     (Vector3.forward * rotatePowerPerFrame * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (state == State.Alive)
        {
            GameObject colObj = collision.gameObject;
            switch (colObj.tag)
            {
                case "Friendly":
                    break;
                case "Enemy":
                    if (state != State.Damaging)
                    {
                        if (playerHealth.currentHealth >= damage)
                        {
                            state = State.Damaging;
                            damagedPS.Play();
                            playerHealth.TakeDamage(damage);
                            audioSource1.PlayOneShot(collisionSound);
                            Invoke("ResetAlive", collisionSound.length);
                        }
                        else
                        {
                            deathPS1.Play();
                            audioSource1.Stop();
                            audioSource1.PlayOneShot(deadSound);
                            enginePS.Stop();
                            Invoke("ifDie", deadSound.length + transitionTime);
                            state = State.Dying;
                        }
                    }
                    break;
                case "Fuel":
                    audioSource1.PlayOneShot(powerUpSound);
                    ifPowerUp();
                    break;
                case "Finish":
                    audioSource1.Stop();
                    successPS.Play();
                    audioSource1.PlayOneShot(finishSound);
                    Invoke("ifFinish", finishSound.length + transitionTime);
                    state = State.Transcending;
                    break;
            }
        }
    }

    private void ifDie(){
        SceneManager.LoadScene(currentLevel);
    }

    private void ifFinish(){
        currentLevel += 1;
        SceneManager.LoadScene(currentLevel);
    }

    private void ifPowerUp(){
        
    }

    private void ResetAlive(){
        state = State.Alive;
    }
}
