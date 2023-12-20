using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float freezeDuration = 1.5f;
    private Animator enemyAnimator;


    void Start(){

        enemyAnimator = transform.parent.GetComponent<Animator>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.tag == "Player"){
            GetComponentInParent<Enemies>().StopMovementOnX();
            enemyAnimator.SetTrigger("Attack");
            // WaitForSeconds(freezeDuration);
            // GetComponentInParent<Enemies>().StartMovementOnX();
        }
    }

}
