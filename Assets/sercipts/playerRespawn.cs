using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerRespawn : MonoBehaviour
{
    public static int playerLives = 3;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if( !IsCollisionFromTop(collision))
            {
            RestartLevel();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) //player object is colliding with a collider that is set as a trigger
    {
        if(collision.gameObject.CompareTag("DeathZone"))
        {
            playerLives--; //reduce player lives by 1
            if(playerLives > 0)
            {
                Debug.Log(playerLives + "lives left");
                RestartLevel();
            }else
            {
                Debug.Log("Game Over");
                SceneManager.LoadScene("endScreen");
            }
        }
              if(collision.gameObject.CompareTag("Flag"))
              {
                Debug.Log("Player has reached the flag");
                SceneManager.LoadScene("Level2");
              }

            if(collision.gameObject.CompareTag("endFlag"))
            {
                Debug.Log("Player has reached the flag");
                SceneManager.LoadScene("WinningScreen");
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
