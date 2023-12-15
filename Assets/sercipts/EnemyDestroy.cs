using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    Private Animator enemyAnimator;

    void Start()
    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            enemyAnimator = transform.parent.GetComponet<Animator>();
        }
        if(collision.gameObject.tag == "Player")
        {
            enemyAnimator.SetTrigger("Destroy");
            Invoke("DestoryEnemy", 0.5f);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(transform.parent.gameObject);
    }
}
