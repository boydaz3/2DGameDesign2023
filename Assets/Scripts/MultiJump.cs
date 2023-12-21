using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cacian Rodriguez-Rolon

public class MultiJump : MonoBehaviour
{
    public float movementSpeed = 15f;
    public float jumpForce = 25f;
    public int jumpCharges = 2;
    private int jumpChargesLeft;
    private Rigidbody2D rb;
    public Animator animator;
    float horizontalMovement = 0f;
    public float terminalVelocity = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpChargesLeft = jumpCharges;
    }

    // Update is called once per frame
    void Update()
    {
        //Controls horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;
        Vector2 movementVector = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        
        animator.SetFloat("sevSpeed", Mathf.Abs(horizontalMovement));
        animator.SetFloat("vertVelocity", rb.velocity.y);

        //Controls the players jump
        if(Input.GetButtonDown("Jump") && jumpChargesLeft > 0)
        {
            movementVector.y = jumpForce;
            jumpChargesLeft--;
            animator.SetBool("isJumping", true);
        }

        //Actually causes player to move
        rb.velocity = movementVector;

        //Flips the player in the direction they're moving in
        if(horizontalInput < 0)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }
        else if(horizontalInput > 0)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }

        if(rb.velocity.magnitude > terminalVelocity)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, terminalVelocity);
        }
    }

    //Resets jumps when the player makes contact with a collider tagged "Ground"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpChargesLeft = jumpCharges;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }
    }

    //Detects when the player leaves the ground, by jumping or falling
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isFalling", true);
        }
    }
}