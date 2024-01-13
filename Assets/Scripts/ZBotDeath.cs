using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cacian Rodriguez-Rolon

public class ZBotDeath : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCol;
    public Rigidbody2D rb;
    private int hp = 0;
    
    void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
        rb = transform.parent.GetComponent<Rigidbody2D>();
    }
    
    //Detects when the box collider on the head makes contact with a player's collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && hp == 0)
        {
            animator.SetTrigger("Killed");
            transform.parent.tag = "Ground";
            Wait(0.75f);
            animator.SetBool("isDead", true);
            hp = -1;
        }
        else if(hp > 0)
        {
            hp--;
            animator.SetTrigger("Hit");
            transform.parent.tag = "Untagged";
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Wait(0.75f);
            transform.parent.tag = "Enemy";
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}

/*
Sidenote: The reason I'm disabling the colliders is so that the player goes through the enemy during the
death animation. Making it seem like the player fell through the enemy, causing it to die.
*/