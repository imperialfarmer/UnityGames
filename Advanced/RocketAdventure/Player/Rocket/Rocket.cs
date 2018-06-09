using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    [SerializeField] float thrustPowerPerFrame = 50f;
    [SerializeField] float rotatePowerPerFrame = 300f;
    [SerializeField] float transitionTime = 1f;
    [SerializeField] float floatForce = 20f;

    public static int currentLevel;
    [SerializeField] int damage = 25;

    [SerializeField] ParticleSystem enginePS;
    [SerializeField] ParticleSystem successPS;
    [SerializeField] ParticleSystem damagedPS;
    [SerializeField] ParticleSystem deathPS1;
    [SerializeField] ParticleSystem deathPS2;
    [SerializeField] AudioClip collisionSound;
    [SerializeField] AudioClip deadSound;
    [SerializeField] AudioClip engineSound;
    [SerializeField] AudioClip finishSound;

    private AudioSource audioSource;
    private enum State { Transcending, Alive, Dying, Damaging };
    private State state = State.Alive;
    private PlayerHealth playerHealth;
    private Animator animator;

	void Start () {
        if (currentLevel <= 3) currentLevel = 3;
        audioSource = GetComponent<AudioSource>();
        playerHealth = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
        animator.SetBool("isDead", false);
	}
	
	void Update () {
        if (playerHealth.currentHealth < playerHealth.maxHealth) 
            deathPS2.Play();
        else 
            deathPS2.Stop();

        if (state == State.Alive)
        {
            Thrust();
            Rotate();
        }

        ShieldLight(playerHealth.currentShield/playerHealth.maxShield);

        if(playerHealth.DieBecauseDebuff){
            ReactToDeath();
            playerHealth.DieBecauseDebuff = false;
        }
	}

    public static void GoTo(int level){
        currentLevel = level;
    }

    private void Thrust(){
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddRelativeForce
                     (Vector3.up * thrustPowerPerFrame);
            if (!audioSource.isPlaying) audioSource.PlayOneShot(engineSound);
            enginePS.Play();
        } else
        {
            audioSource.Stop();
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
                        if(playerHealth.currentHealth + playerHealth.currentShield > damage)
                        {
                            ReactToDamage(damage);
                        }
                        else{
                            ReactToDeath();
                        }
                    }
                    break;
                case "ThunderBorder":
                    if (state != State.Damaging)
                    {
                        playerHealth.TakeDamage(damage*10);
                        deathPS1.Play();
                        audioSource.Stop();
                        audioSource.PlayOneShot(deadSound);
                        enginePS.Stop();
                        Invoke("ifDie", deadSound.length);
                        GetComponent<Collider>().enabled = false;
                        //gameObject.tag = "Default";
                        state = State.Dying;
                        animator.SetBool("isDead", true);
                    }
                    break;
                case "Lava":
                    if (state != State.Damaging)
                    {
                        if (playerHealth.currentHealth <= damage*2 && playerHealth.currentShield <= 0)
                        {
                            playerHealth.TakeDamage(damage*2);
                            deathPS1.Play();
                            audioSource.Stop();
                            audioSource.PlayOneShot(deadSound);
                            enginePS.Stop();
                            Invoke("ifDie", deadSound.length);
                            GetComponent<Collider>().enabled = false;
                            //gameObject.tag = "Default";
                            state = State.Dying;
                            animator.SetBool("isDead", true);
                        }
                        else
                        {
                            state = State.Damaging;
                            damagedPS.Play();
                            playerHealth.TakeDamage(damage*2);
                            audioSource.PlayOneShot(collisionSound);
                            Invoke("ResetAlive", 0.5f);
                        }
                    }
                    break;
                case "Finish":
                    audioSource.Stop();
                    successPS.Play();
                    audioSource.PlayOneShot(finishSound);
                    Invoke("ifFinish", finishSound.length + transitionTime);
                    state = State.Transcending;
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject triObj = other.gameObject;
        if(triObj.tag == "Border" && state == State.Alive){
            ifDie();
        }
        if(triObj.tag == "Thunder"){
            if(playerHealth.currentShield <= 0){
                playerHealth.TakeDamage(damage * 10);
                deathPS1.Play();
                audioSource.Stop();
                audioSource.PlayOneShot(deadSound);
                enginePS.Stop();
                Invoke("ifDie", deadSound.length);
                GetComponent<Collider>().enabled = false;
                //gameObject.tag = "Default";
                state = State.Dying;
                animator.SetBool("isDead", true);
            }
        }
    }

    private void ifDie(){
        SceneManager.LoadScene(currentLevel);
        animator.SetBool("isDead", false);
    }

    private void ifFinish(){
        currentLevel += 1;
        Debug.Log("Next Level = " + currentLevel);
        PlayerPrefsManager.UnlockLevel(currentLevel);
        SceneManager.LoadScene(currentLevel);
    }

    private void ResetAlive(){
        state = State.Alive;
    }

    private void ShieldLight(float shield){
        if(shield <= 0f){
            transform.GetChild(0).gameObject.
                     GetComponent<Light>().intensity = 0f;
        }
        else if (shield <= 0.5f)
        {
            transform.GetChild(0).gameObject.
                     GetComponent<Light>().intensity = 0.5f;
        }
        else if(shield >= 1f)
        {
            transform.GetChild(0).gameObject.
                     GetComponent<Light>().intensity = 1f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject colObj = other.gameObject;
        if(colObj.tag == "Water"){
            GetComponent<Rigidbody>().AddForce(Vector3.up * floatForce);
        }
    }

    public void ReactToDamage(int incomingDamage){
        state = State.Damaging;
        damagedPS.Play();
        playerHealth.TakeDamage(incomingDamage);
        audioSource.PlayOneShot(collisionSound);
        Invoke("ResetAlive", 0.5f);
    }

    public void ReactToDeath(){
        playerHealth.TakeDamage(damage);
        deathPS1.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(deadSound);
        enginePS.Stop();
        Invoke("ifDie", deadSound.length);
        GetComponent<Collider>().enabled = false;
        //gameObject.tag = "Default";
        state = State.Dying;
        animator.SetBool("isDead", true);
    }

}
