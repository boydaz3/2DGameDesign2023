using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static void SwitchToLevel(int level)
    {
        SceneManager.LoadScene("Level" + level);
    }
}
