using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1select : MonoBehaviour
{
    public void StartLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}
