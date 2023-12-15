using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject robotPartic;
    void Start()
    {
        
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            this.gameObject.GetComponent<TakeDamage>().Damage();
            return;
        }
        if (collision.gameObject.layer != 8) return;
        Debug.Log(collision.gameObject);
        if (!collision.isTrigger)
        {
            this.gameObject.GetComponent<TakeDamage>().Damage();
            return;
        }
        Destroy(collision.gameObject);
        GameObject robotPartic1 = Instantiate(robotPartic, collision.transform.position, collision.transform.rotation);
        Destroy(robotPartic1, robotPartic1.GetComponent<ParticleSystem>().main.startLifetime.constant);
        this.gameObject.GetComponent<MoveSprite>().Jump();
    }
}
