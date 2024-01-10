using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    public float PlatformSpeed = 10f;
    public GameObject pointStart;
    public GameObject pointGoUp;
    public GameObject pointEnd;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }

    private void Update()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.rotation = Mathf.Clamp(rb.rotation, -10, 10);
        if (rb.rotation < -5f && transform.position.x < pointEnd.transform.position.x)
        {
            rb.AddForce(new Vector2(PlatformSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);
            if (transform.position.x > pointGoUp.transform.position.x)
            {
                rb.constraints = RigidbodyConstraints2D.None; 
                rb.AddForce(new Vector2(0, PlatformSpeed * Time.deltaTime), ForceMode2D.Impulse);
            }
        }
        if (rb.rotation > 5f && transform.position.x > pointStart.transform.position.x && 
            transform.position.x < pointEnd.transform.position.x)
        {
            rb.AddForce(new Vector2(-PlatformSpeed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }

        if (transform.position.x >= pointEnd.transform.position.x)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }

}
