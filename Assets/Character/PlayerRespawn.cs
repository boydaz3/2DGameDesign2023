using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerRespawn : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Enemy")){
           RestartLevel();
        }
    }

    private void RestartLevel (){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
