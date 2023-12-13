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
            Debug.Log(isCollisionFromTop(collision));
            if (!isCollisionFromTop(collision))
            {
                RestartLevel();
            }
        }
    }

    private bool isCollisionFromTop(Collision2D collision)
    {
        return transform.position.y > collision.gameObject.transform.position.y+0.2f;

    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
