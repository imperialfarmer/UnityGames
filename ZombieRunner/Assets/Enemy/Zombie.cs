using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public float damage = 20f;
    private Animator animator;
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject col = collision.gameObject;
        if(col && col.GetComponent<Player>()){
            Player player = col.GetComponent<Player>();
            animator.SetBool("isAttacint", true);
            if(player.health >= 0){
                player.health -= damage;
            }else{
                if (player.chance > 0)
                {
                    player.respawn = true;
                    player.chance -= 1;
                }
                else{
                    // lose scene
                }
            }
        }
    }


}
