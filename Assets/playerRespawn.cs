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
          
           RestartLevel();
            
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
        }
       }
       if(collision.gameObject.CompareTag("Goal"))
       {
        Debug.Log("player has reached the Goal");
        SceneManager.LoadScene("To Ezz");
       }
    }



    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
