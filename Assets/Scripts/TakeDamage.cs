using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private string mainMenuScene;
    [SerializeField] private Transform spawnPoint;
    public static TakeDamage instance;
    [SerializeField] public static float lives = 3;
    [SerializeField] private TextMeshProUGUI livesText;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        instance = this;
    }
    private void Update()
    {
        if (lives <= 0) GameOver();
        livesText.text = $"Lives: {lives}";
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 8) return;
        if (collision.collider.isTrigger) return;
    }
    public void Damage()
    {
        this.transform.position = spawnPoint.position;
        lives-=1;
    }
    private void GameOver()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
