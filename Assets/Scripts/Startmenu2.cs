using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startmenu2: MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level 2");
    }
}