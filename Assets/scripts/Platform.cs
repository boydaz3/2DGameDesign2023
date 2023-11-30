using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isJumping = false;
    private Rigidbody2D rb;
    public Animator animator;

    float HorizontalMovement = 0f;
        // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //code for horizonal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float HorizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
        Vector2 moveVector = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(HorizontalMovement));

        //player is jumping
        if(Input.GetButtonDown("Jump") && !isJumping){
            moveVector.y = jumpForce;
            isJumping = true;
            animator.SetBool("isJumping" , true);
        }

        rb.velocity = moveVector;

        if(horizontalInput < 0){
            transform.localScale = new Vector3(-1, 1, 1);
        } else if(horizontalInput > 0){
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isJumping = false;
            animator.SetBool("isJumping" , false);
        }
    }
}
