using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{
    public float moveSpeed = 6.0f;
    public float jumpForce = 21.0f;

    public Boolean isJumping = false;
    public Boolean isGrounded = false;

    public Rigidbody2D rb;
    private Animator anim;

    public Transform respawnPoint; // Add this variable to store the respawn point

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Set the initial respawn point to the player's starting position
        respawnPoint = transform;
    }

    public bool facingRight = true;

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveVector = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            moveVector.y = jumpForce;
            isJumping = true;
        }

        rb.velocity = moveVector;

        if (isGrounded == false)
        {
            anim.SetBool("isGrounded", false);
        }

        if (isGrounded == true)
        {
            anim.SetBool("isGrounded", true);
        }

        if (isJumping == false)
        {
            anim.SetBool("jumped", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
            anim.SetBool("jumped", true);
        }

        // Check for death
        if (Input.GetKeyDown(KeyCode.K))
        {
            Die();
        }
    }

    void Die()
    {
        // Play death animation
        Debug.Log("Died");
        anim.SetTrigger("hurt");
        // Reset the player's position to the respawn point
        transform.position = respawnPoint.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Hurt"))
        {
            Debug.Log("Touched spikes");
            anim.SetTrigger("hurt");

            // Call the Die() function when the player touches spikes
            Die();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
