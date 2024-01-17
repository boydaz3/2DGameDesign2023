using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    private Animator animator;
    private bool isBeingTouched;
    private Vector3 currentVelocity;
    public GameObject interactionKey;
    private Vector3 originalScale;
    private Vector3 zero = new Vector3(0, 0, 0);
    public Animator crossFadePanel;
    private bool hasAlreadyBeenInteractedWith = false;
    public string sceneName = "Level2";
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        originalScale = interactionKey.transform.localScale;
        interactionKey.transform.localScale = zero;
    }

    public void onTouch()
    {
        isBeingTouched = true;
        animator.SetTrigger("DoDoorOpen");
    }

    public void onUnTouch()
    {
        isBeingTouched = false;
        animator.SetTrigger("DoDoorClose");
    }
    
    void Update()
    {
        if (isBeingTouched)
        {
            interactionKey.transform.localScale =
                Vector3.SmoothDamp(interactionKey.transform.localScale, originalScale, ref currentVelocity, 0.4f);

            if (Input.GetKeyDown(KeyCode.E) && !hasAlreadyBeenInteractedWith)
            {
                crossFadePanel.SetTrigger("DoCrossFade");
                hasAlreadyBeenInteractedWith = true;
                StartCoroutine(LoadLevel(sceneName, 0.5f));
            }
        }
        else
        {
            interactionKey.transform.localScale =
                Vector3.SmoothDamp(interactionKey.transform.localScale, zero, ref currentVelocity, 0.4f);
        }
    }
    
    IEnumerator LoadLevel(string sceneName, float transitionTime)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
    
}
