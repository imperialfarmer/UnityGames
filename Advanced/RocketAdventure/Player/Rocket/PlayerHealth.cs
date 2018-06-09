/* Written by Kaz Crowe */
/* PlayerHealth.cs */
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	static PlayerHealth instance;
	public static PlayerHealth Instance { get { return instance; } }
	bool canTakeDamage = true;

	public int maxHealth = 100;
	public float currentHealth = 0;
	public float invulnerabilityTime = 0.5f;

	public float currentShield = 0;
	public int maxShield = 25;
	float regenShieldTimer = 0.0f;
	public float regenShieldTimerMax = 1.0f;
    public int regenShield = 0;

	public GameObject explosionParticles;

	public SimpleHealthBar healthBar;
	public SimpleHealthBar shieldBar;


    public bool DieBecauseDebuff = false;

	void Awake ()
	{
		// If the instance variable is already assigned, then there are multiple player health scripts in the scene. Inform the user.
		if( instance != null )
			Debug.LogError( "There are multiple instances of the Player Health script. Assigning the most recent one to Instance." );
		
		// Assign the instance variable as the Player Health script on this object.
		instance = GetComponent<PlayerHealth>();
	}

	void Start ()
	{
        currentShield = 0;
        // set max value dependant on upgrades
        SetUpgrade();
        // Set the current health to max values and shield to 0
		currentHealth = maxHealth;
		
		// Update the Simple Health Bar with the updated values of Health and Shield.
		healthBar.UpdateBar( currentHealth, maxHealth );
		shieldBar.UpdateBar( currentShield, maxShield );
	}

	void Update ()
	{
		// If the shield is less than max, and the regen cooldown is not in effect...
		if( currentShield < maxShield && regenShieldTimer <= 0 )
		{
			// Increase the shield.
            currentShield += Time.deltaTime * regenShield;

			// Update the Simple Health Bar with the new Shield values.
			shieldBar.UpdateBar( currentShield, maxShield );
		}

		// If the shield regen timer is greater than zero, then decrease the timer.
		if( regenShieldTimer > 0 )
			regenShieldTimer -= Time.deltaTime;
	}

	public void HealPlayer (int heal)
	{
        currentHealth += heal;

		if( currentHealth > maxHealth )
			currentHealth = maxHealth;

		// Update the Simple Health Bar with the new Health values.
		healthBar.UpdateBar( currentHealth, maxHealth );
	}

    public void RechargeShield(int recharge)
    {
        currentShield += recharge;
        if (currentShield > maxShield)
            currentShield = maxShield;
        
        shieldBar.UpdateBar(currentShield, maxShield);
    }

	public void TakeDamage ( int damage )
	{
		// If the player can't take damage, then return.
		if( canTakeDamage == false )
			return;

		// If the shield value is greater than 0...
		if( currentShield > 0 )
		{
			// Reduce the current shield value.
			currentShield -= damage;

			// If the shield is now less than 0...
			if( currentShield < 0 )
			{
				// Reduce the health by how much damage went past the shield.
				currentHealth -= currentShield * -1;

				// Set the shield to zero.
				currentShield = 0;
			}
		}
		// Else there was no shield, so reduce health.
		else
			currentHealth -= damage;

		// Set canTakeDamage to false to make sure that the player cannot take damage for a brief moment.
		canTakeDamage = false;

		// Run the Invulnerablilty coroutine to delay incoming damage.
		StartCoroutine( "Invulnerablilty" );

		// Shake the camera for a moment to make each hit more dramatic.
		StartCoroutine( "ShakeCamera" );

		// Update the Health and Shield status bars.
		healthBar.UpdateBar( currentHealth, maxHealth );
		shieldBar.UpdateBar( currentShield, maxShield );

		// Reset the shield regen timer.
		regenShieldTimer = regenShieldTimerMax;
	}

	IEnumerator Invulnerablilty ()
	{
		// Wait for the invulnerability time variable.
		yield return new WaitForSeconds( invulnerabilityTime );

		// Then allow the player to take damage again.
		canTakeDamage = true;
	}

	IEnumerator ShakeCamera ()
	{
		// Store the original position of the camera.
		Vector3 origPos = Camera.main.transform.position;
		for( float t = 0.0f; t < 1.0f; t += Time.deltaTime * 2.0f )
		{
			// Create a temporary vector2 with the camera's original position modified by a random distance from the origin.
			Vector2 tempVec = Random.insideUnitCircle;

			// Apply the temporary vector.
            Camera.main.transform.position += 
                new Vector3(tempVec[0],tempVec[1],0f);

			// Yield until next frame.
			yield return null;
		}

		// Return back to the original position.
		Camera.main.transform.position = origPos;
	}

    private void SetUpgrade(){
        int originalMaxHealth = maxHealth;
        if (PlayerPrefsManager.CheckMatInThisLevel("upgrade_2_"))
        {
            maxHealth += Mathf.RoundToInt(originalMaxHealth * 0.5f);
        }
        if (PlayerPrefsManager.CheckMatInThisLevel("upgrade_3_"))
        {
            maxHealth += Mathf.RoundToInt(originalMaxHealth * 0.5f);
        }
        if (PlayerPrefsManager.CheckMatInThisLevel("upgrade_0_"))
        {
            currentShield += Mathf.RoundToInt(maxShield * 0.5f);
        }
        if (PlayerPrefsManager.CheckMatInThisLevel("upgrade_1_"))
        {
            currentShield += Mathf.RoundToInt(maxShield * 0.5f);
        }
    }



    public void TakeContinuosDamage(int incomingDamage)
    {
        int damage;
        if (currentShield > 0) damage = Mathf.RoundToInt(incomingDamage / 2);
        else damage = incomingDamage;
        if (currentHealth >= damage)
        {
            currentHealth -= damage;
            healthBar.UpdateBar(currentHealth, maxHealth);
        }
        else{
            DieBecauseDebuff = true;
        }
    }
}