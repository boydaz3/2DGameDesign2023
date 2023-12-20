using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    public PhysicsMaterial2D enemyHitBoxMaterial;
    public Collider2D collider;
    public Animator animator;

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
                    Destroy(collision.gameObject);
                }
                else
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
                Debug.Log("Finish");
                break;
        }
        
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
