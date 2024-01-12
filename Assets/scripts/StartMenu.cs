using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level Select");
    }

     public void StartLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

     public void StartLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
