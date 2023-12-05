using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerRespawn : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(!IsCollisionFromTop(collision))
            {
                RestartLevel();
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