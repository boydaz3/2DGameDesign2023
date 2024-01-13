using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public static int playerLives = 3;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    //Detects collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks if the collision is with an Enemy object
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //Restarts the level, or in this case game, if the collision was not with the enemys head
            if(!isStomping(collision))
            {
                SceneLoader.ReloadLevel();
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, MultiJump.jumpForce/2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if the trigger the player has made contact with is tagged with DeathZone
        if(collision.gameObject.CompareTag("DeathZone"))
        {
            /*
            Decrements the number of lives and restarts with a message displaying remaining lives or
            displays a "Game Over" message
            */
            playerLives--;
            if(playerLives > 0)
            {
                Debug.Log("Lives: " + playerLives);
                SceneLoader.ReloadLevel();
            }
            else
            {
                SceneLoader.GameOver();
                Debug.Log("A fatal exception error has occurred. Please avoid dying in the future. :)");
            }
        }
    }

    /*
    Checks the y value of the player and compares it to the y value of the colliding enemy
    If the player is higher than the enemy, the isStomping returns true, if not, returns false
    The + 0.1f is there to fix issues with the enemy dying when colliding with the player at the same
    visible level, depsite an extremely small difference in their y-positions, causing the enemy to die
    unless collided with from below.
    */
    private bool isStomping(Collision2D collision)
    {
        return transform.position.y > collision.gameObject.transform.position.y + 0.1f;
    }
}
