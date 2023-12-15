using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private Animator enemyAnimator;

    void Start()
    {
        enemyAnimator = transform.parent.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            enemyAnimator.SetTrigger("Destroy");
            Invoke("DestroyEnemy", 0.8f);
        }
    }

    public void DestroyEnemy()
    {
         Destroy(transform.parent.gameObject);
    }
}
