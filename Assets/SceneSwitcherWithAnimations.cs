using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitcherWithAnimations : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void MainMenuToLevel()
    {
        animator.SetTrigger("doMainMenuAnimation");
    }
}
