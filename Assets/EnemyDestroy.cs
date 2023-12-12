using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public PhysicsMaterial2D enemyHitBoxMaterial;
    public Collider2D collider;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collider = collision.collider;
        if (collision.gameObject.name == "EnemySprite" && collision.collider.sharedMaterial == enemyHitBoxMaterial)
        {
            
            Destroy(collision.gameObject);
        }
    }
}
