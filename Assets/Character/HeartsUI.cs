using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void UpdateHearts(int currentLives)
    {
        if (currentLives == 3) { anim.SetBool("Heart3", true); }
        else if (currentLives == 2) { anim.SetBool("Heart2", true); anim.SetBool("Heart3", false);}
        else if (currentLives == 1) { anim.SetBool("Heart1", true);  anim.SetBool("Heart2", false);}
    }
}
