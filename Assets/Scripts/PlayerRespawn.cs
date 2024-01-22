using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public static int playerlives = 3;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(!IsCollisionFromTop(collision))
            {
                RestartLevel();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            playerlives--;
            if(playerlives > 0)
            {
                Debug.Log(playerlives + "lives left");
                RestartLevel();
            }
            else
            {
                Debug.Log("Game Over");
            }
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Player has reached the flag");
            SceneManager.LoadScene("Level 2");
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene("Winscreen");
        }
        if (collision.gameObject.CompareTag("Goal 2"))
        {
            SceneManager.LoadScene("Start screen");
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
