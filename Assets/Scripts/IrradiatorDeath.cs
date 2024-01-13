using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cacian Rodriguez-Rolon

public class IrradiatorDeath : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCol;
    
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
    }
    
    //Detects when the box collider on the head makes contact with a player's collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Kills the enemy by activating the "Killed" trigger, setting isDead to true, disabling the
            //box collider, and destroying the object once the animation finishes
            animator.SetTrigger("Killed");
            animator.SetBool("isDead", true);
            boxCol.enabled = false;
            //Did the math, 14 frame animation player at 32 FPS takes 0.4375 seconds to play
            Invoke("Destroy", 0.4375f);
        }
    }

    //Does what it says on the box, destroys the entire gameObject when called
    public void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}

/*
Sidenote: The reason I'm disabling the colliders is so that the player goes through the enemy during the
death animation. Making it seem like the player fell through the enemy, causing it to die.
*/