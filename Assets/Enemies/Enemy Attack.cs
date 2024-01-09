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
    private IEnumerator OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.tag == "Player"){
            GetComponentInParent<Enemies>().StopMovementOnX();
            enemyAnimator.SetTrigger("Attack");
            yield return new WaitForSeconds (1.3f);
            if(collision.gameObject.tag == "Player"){
                RestartLevel();
            }
            yield return new WaitForSeconds (0.3f);
            GetComponentInParent<Enemies>().StartMovementOnX();
        }
    }

    private void RestartLevel (){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
