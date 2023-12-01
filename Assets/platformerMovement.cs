using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class platformer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool isJumping = false;
    private Rigidbody2D rb;

    public Animator animator;

    float horizontalMovement = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Code for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
        Vector2 moveVector = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        animator.SetFloat("speed", Mathf.Abs(horizontalMovement));

        // Player is jumping
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            moveVector.y = jumpForce;
            isJumping = true;
        }

        rb.velocity = moveVector;

        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-5, 5, 5); // Flip the character to face left
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(5, 5, 5); // Reset the scale to face right
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}






