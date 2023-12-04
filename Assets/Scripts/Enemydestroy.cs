using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Enemydestroy : MonoBehaviour
{
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
//this is a comment mehehe