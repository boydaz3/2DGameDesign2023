using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerRespawn : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(isCollisionFromTop(collision));
            if (!isCollisionFromTop(collision))
            {
                playerLives--;
                if (playerLives > 0)
                {    
                    Debug.Log(playerLives + " lives left");
                    RestartLevel();
                }else
                {
                    SceneManager.LoadScene("Die Screen");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //player object is colliding with a collider that is set as a trigger
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            playerLives--; //reduce player lives by 1
            if(playerLives > 0)
            {
                Debug.Log(playerLives + " lives left");
                RestartLevel();
            }else
            {
                SceneManager.LoadScene("Die Screen");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //player object is colliding with a collider that is set as a trigger
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            playerLives--; //reduce player lives by 1
            if(playerLives > 0)
            {
                Debug.Log(playerLives + " lives left");
                RestartLevel();
            }else
            {
                Debug.Log("Game Over");
            }
        }
    }

    private bool isCollisionFromTop(Collision2D collision)
    {
        return transform.position.y > collision.gameObject.transform.position.y+0.4f;
        
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
