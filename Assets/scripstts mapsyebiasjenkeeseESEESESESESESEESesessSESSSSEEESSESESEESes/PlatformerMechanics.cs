using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlatformerMechanics : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isJumping = false;
    public float torqueForce = 2f;


    private Rigidbody2D rb;
    
    // start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // update is called once per frame
    void Update()
    {
        // Adds Torque
        float torqueInput = Input.GetAxis("Horizontal");
        rb.AddTorque(-torqueInput * torqueForce);

        if (isJumping)
        {
            torqueForce = 0;

        }


        // code for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveVector = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // player is jumping
        if (Input.GetButtonDown("Jump") && !isJumping){
            
            moveVector.y = jumpForce;
            isJumping = true;
        }

        rb.velocity = moveVector;

        if(horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if(horizontalInput > 0){
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            torqueForce = 4;
            isJumping = false;
        }
    }
}