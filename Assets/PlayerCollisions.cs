using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    public PhysicsMaterial2D enemyHitBoxMaterial;
    public Collider2D collider;
    public Animator animator;
    public PhysicsMaterial2D enemyHurtBoxMaterial;
    public TMP_Text livesText;
    public CaveOpening CaveOpening;

    [SerializeField]
    private int lives = 3;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // for debug purposes
        collider = collision.collider;

        switch (collision.gameObject.name)
        {
            case "EnemySprite":
                
                if (collision.collider.sharedMaterial == enemyHitBoxMaterial)
                {
                    foreach (var boxCollider2D in collision.gameObject.GetComponents<BoxCollider2D>())
                    {
                        boxCollider2D.enabled = false;
                    }

                    collision.gameObject.GetComponent<CircleCollider2D>().sharedMaterial = null;
                    collision.gameObject.GetComponent<Enemy>().isAlive = false;
                    collision.gameObject.GetComponent<Animator>().SetTrigger("death");

                }
                else if (collision.collider.sharedMaterial == enemyHurtBoxMaterial)
                {
                    DecrementLives();
                }
                break;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // for debug purposes
        collider = collision.GetComponent<Collider2D>();
        switch (collision.gameObject.tag)
        {
            case "Void":
                RestartLevel();
                break;
            case "FinishFlag":
                SceneManager.LoadScene("Win");
                break;
            case "CaveOpening":
                CaveOpening.onEnter();
                break;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "CaveOpening":
                CaveOpening.onExit();
                break;
        }
    }

    private void Start()
    {
        livesText.SetText("Lives: " + lives);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetLives()
    {
        return lives;
    }

    public void SetLives(int setLives)
    {
        if (lives > 0)
        {
            lives = setLives;
            livesText.SetText("Lives: " + lives);
        }
        else
        {
            GameOver();
        }
    }

    public void DecrementLives()
    {
        animator.SetTrigger("Hurt");
        SetLives(GetLives() - 1);
    }
    
}
