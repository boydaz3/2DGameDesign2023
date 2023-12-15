using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button startButton;
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        Debug.Log("AAA");
        SceneManager.LoadScene("SampleScene");
    }
}
