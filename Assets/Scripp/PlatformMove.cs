using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
   public float movespeed = 5f;
   public float jumpforce = 10f;
   private bool isjumping = false;

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
        //code for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        horizontalMovement = Input.GetAxis("Horizontal") * movespeed;
        Vector2 moveVector = new Vector2(horizontalInput * movespeed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        //player is jumping
        if(Input.GetButtonDown("Jump") && !isjumping){
            moveVector.y = jumpforce;
            isjumping = true;
            animator.SetBool("isjumping" , true);
        }

        rb.velocity = moveVector;

        if(horizontalInput < 0){
            transform.localScale = new Vector3(-2, 2, 1);
        } else if(horizontalInput > 0){
            transform.localScale = new Vector3(2, 2, 1);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isjumping = false;
            animator.SetBool("isjumping" , false);
        }
    }

}