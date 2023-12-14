using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private Animator enemyAnimation;

    void Start()
    {
        enemyAnimation = transform.parent.GetComponent<Animator>();
     }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemyAnimator.SetTrigger("Destroy")
            Destroy(transform.parent.gameObject);
        }
    }
}
