using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        playerRespawn.playerLives = 3;
        SceneManager.LoadScene("Level1");
    }
}
