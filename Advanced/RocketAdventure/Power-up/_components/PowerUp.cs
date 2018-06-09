using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField] int type;
    [SerializeField] int amount;

    private AudioSource audioSource;
    [SerializeField] ParticleSystem obtainEffect;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (!audioSource) Debug.LogError("PowerupSound not Found");
        if(type == 2){
            string mat = "material_" + amount + "_";
            //print("check " + mat);
            if (PlayerPrefsManager.CheckMatInThisLevel(mat)){
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        GameObject colObj = col.gameObject;
        if(colObj.tag == "Friendly"){
            obtainEffect.Play();
            audioSource.Play();
            if (type == 0)
            {
                colObj.GetComponent<PlayerHealth>().HealPlayer(amount);
            }
            if (type == 1)
            {
                colObj.GetComponent<PlayerHealth>().RechargeShield(amount);
            }
            if (type == 2){
                PlayerPrefsManager.MaterialObtained(amount);
            }
            if(GetComponent<CapsuleCollider>())
                GetComponent<CapsuleCollider>().enabled = false;
            if (GetComponent<SphereCollider>())
                GetComponent<SphereCollider>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            Invoke("DestroyThis", audioSource.clip.length);
        }
    }

    void DestroyThis(){
        Destroy(gameObject);
    }
}
