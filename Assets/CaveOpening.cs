using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveOpening : MonoBehaviour
{
    private bool isPlayerInsideTrigger = false;
    public RectTransform EButtonUsePrompt;
    private Vector3 currentVelocity = Vector3.zero;
    private const float normalScale = 0.01079f;
    public void onEnter()
    {
        isPlayerInsideTrigger = true;
    }
    
    public void onExit()
    {
        isPlayerInsideTrigger = false;
    }

    private void Update()
    {
        Vector3 target = new Vector3(isPlayerInsideTrigger ? normalScale : 0f, isPlayerInsideTrigger ? normalScale : 0f,
            isPlayerInsideTrigger ? normalScale : 0f);
        
        EButtonUsePrompt.localScale = Vector3.SmoothDamp(EButtonUsePrompt.localScale,
            target, ref currentVelocity, 0.2f);

        if (isPlayerInsideTrigger && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Cave");
        }
    }
}
