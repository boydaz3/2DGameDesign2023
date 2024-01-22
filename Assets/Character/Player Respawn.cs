using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public static int playerLives = 3;
    public HeartsUI heartsUI;

    private void Start()
    {
        // Assuming you have a reference to the HeartsUI component
        heartsUI = FindFirstObjectByType<HeartsUI>();
        if (heartsUI != null)
        {
            heartsUI.UpdateHearts(playerLives);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerLives--;
            if (heartsUI != null)
            {
                Debug.Log(playerLives + " lives left");
                heartsUI.UpdateHearts(playerLives);
            }
            else
            {
                SceneManager.LoadScene("GameOverScreen");
                playerLives = 3;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            playerLives--;
            if (heartsUI != null)
            {
                Debug.Log(playerLives + " lives left");
                heartsUI.UpdateHearts(playerLives);
            }
            if (playerLives > 0)
            {
                RestartLevel();
            }
            else
            {
                SceneManager.LoadScene("GameOverScreen");
                playerLives = 3;
            }
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
