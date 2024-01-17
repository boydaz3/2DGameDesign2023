using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherWithAnimations : MonoBehaviour
{
    private Animator animator;
    public float transitionTime;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void MainMenuToLevel()
    {
        DoTransition("doMainMenuAnimation", "Level1");
    }

    public void DoTransition(string animationTriggerName, string sceneName)
    {
        animator.SetTrigger(animationTriggerName);
        StartCoroutine(LoadLevel(sceneName, transitionTime));
    }

    IEnumerator LoadLevel(string sceneName, float transitionTime)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
