using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import the UI namespace
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public static int playerLives = 3;
    public Sprite heartSprite; // Reference to the heart sprite
    public Transform heartsParent; // The parent object for the hearts
    private List<Image> heartsList = new List<Image>();

    private void Start()
    {
        // Initialize hearts based on the number of starting lives
        InitializeHearts();
    }

    private void InitializeHearts()
    {
        for (int i = 0; i < playerLives; i++)
        {
            Debug.Log(playerLives);
            Image heart = new GameObject("Heart" + i, typeof(Image)).GetComponent<Image>();
            heart.transform.SetParent(heartsParent);
            heart.sprite = heartSprite;
            heartsList.Add(heart);
        }
    }

    private void UpdateHearts()
    {
        // Update the displayed hearts based on the current number of lives
        for (int i = 0; i < heartsList.Count; i++)
        {
            heartsList[i].enabled = i < playerLives;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerLives--;
            UpdateHearts();
            if (playerLives > 0)
            {
                Debug.Log(playerLives + " lives left");
                RestartLevel();
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
            UpdateHearts();
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
