using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene("Start Screen");
    }
        }
