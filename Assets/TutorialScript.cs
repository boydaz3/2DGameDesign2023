using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{

    private float velocityMovement = 0f;
    private float velocityKillEnemies = 0f;
    private bool isAPressed = false;
    private bool isDPressed = false;
    private bool isShiftPressed = false;
    private bool isSpacePressed = false;

    public CanvasGroup MovementTutorialCanvasGroup;
    public CanvasGroup KillEnemiesTutorialCanvasGroup;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            isAPressed = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            isDPressed = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            isSpacePressed = true;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isShiftPressed = true;
        }

        if (isAPressed && isDPressed && isShiftPressed)
        {
            MovementTutorialCanvasGroup.alpha =
                Mathf.SmoothDamp(MovementTutorialCanvasGroup.alpha, 0f, ref velocityMovement, 1f);
        }

        if (isSpacePressed)
        {
            KillEnemiesTutorialCanvasGroup.alpha =
                Mathf.SmoothDamp(KillEnemiesTutorialCanvasGroup.alpha, 0f, ref velocityKillEnemies, 1f);
        }
    }
}
