using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerRespawn : MonoBehaviour
{
    public static int playerLives = 3;

    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Enemy")){
           RestartLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.CompareTag("DeathZone")){
            playerLives--;
            if(playerLives > 0){
                Debug.Log(playerLives + " lives left");
                RestartLevel();
            }
            else {
                SceneManager.LoadScene("GameOverScreen");
            }
        }
        if(collision.gameObject.CompareTag("Flag")){
            SceneManager.LoadScene("WinScreen");
        }
    }

    private void RestartLevel (){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
