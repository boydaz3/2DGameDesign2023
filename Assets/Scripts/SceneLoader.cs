using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static int currentLevel = 0;
    public void StartGame()
    {
        SceneManager.LoadScene("L1");
        currentLevel = 1;
    }

    public void StartTesting()
    {
        SceneManager.LoadScene("TestingScene");
    }

    public static void NextLevel()
    {
        SceneManager.LoadScene(currentLevel + 1);
        currentLevel++;
    }
    
    public static void ReloadLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }
    
    public static void GameOver()
    {
        SceneManager.LoadScene("BSOD");
    }
}
