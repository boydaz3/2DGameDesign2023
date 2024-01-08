using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public static int playerLives = 3;
    private void OnCollisionEnter2D(Collision2D collision) //example of omCollision fucntion thus is based on the capsuleCollider of the [a;]
    {

       if(collision.gameObject.CompareTag("enemy"))
        {
        if (!IsCollisionFromTop(collision))
            {
            RestartLevel();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) //player object is colliding with a collider that is set on a trigger
    {
        if(collision.gameObject.CompareTag("DeathZone"))
        {
            playerLives--;
            if (playerLives > 0)
            {
                Debug.Log(playerLives + " lives left");
                RestartLevel();
            }else
            {
                Debug.Log("Game Over");
            }
        }
    }

    private bool IsCollisionFromTop(Collision2D collision)
    {
        return transform.position.y > collision.gameObject.transform.position.y;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

