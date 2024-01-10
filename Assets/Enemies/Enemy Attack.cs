using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyAttack : MonoBehaviour
{
    public float freezeDuration = 1.5f;
    private Animator enemyAnimator;


    void Start(){

        enemyAnimator = transform.parent.GetComponent<Animator>();
        
    }
    bool playerStillTouching = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(PerformAttack());
        }
    }

    IEnumerator PerformAttack()
    {
        GetComponentInParent<Enemies>().StopMovementOnX();
        enemyAnimator.SetTrigger("Attack");

        // Wait for the attack animation duration
        yield return new WaitForSeconds(1.3f);

        // Check if the player is still touching the enemy
        if (playerStillTouching)
        {
            RestartLevel();
        }
        else
        {
            // Continue with the rest of the code if the player is not touching
            yield return new WaitForSeconds(0.2f);
            GetComponentInParent<Enemies>().StartMovementOnX();
            // Additional logic for the animation completion and level continuation
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerStillTouching = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerStillTouching = false;
        }
    }

    private void RestartLevel (){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
