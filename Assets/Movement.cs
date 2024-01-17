 // Suvan Mangamuri
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

 public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    // these variables are set in the Unity Editor
    public ParticleSystem particleSystem;
    public ParticleSystem particleSystemJump;
    
    private ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
    private bool doEmitParticles = false;
    
    public float speed = 14f;
    public float jumpSpeed = 6.5f;
    public float boostJumpSpeed = 40f;

    public float velocityCap = 15f;
 
    public Animator animator;
    
    private float currentVelocity;

    public GameObject collidingWith;
    
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        // make sure particle systems arent playing at the start
        particleSystem.Stop();
        particleSystemJump.Stop();


        
        InvokeRepeating("emitParticles", 0, 0.1f);
    }

    // every 100 ms emit particles if player is moving
    private void emitParticles()
    {
        if (doEmitParticles)
        {
            particleSystem.Emit(emitParams, 2);
        }
        
    }
    
    void Update()
    {
        float actualSpeed = speed;
        // Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            actualSpeed *= 1.5f;
            animator.speed = 1.5f;
            // increase camera fov to make the player think that they're going way faster, even though it's only 1.5x speed
            Camera.main.orthographicSize =
                Mathf.SmoothDamp(Camera.main.orthographicSize, 10f, ref currentVelocity, 0.2f);
        }
        else
        {
            actualSpeed = speed;
            animator.speed = 1f;
            // set camera fov to normal
            Camera.main.orthographicSize =
                Mathf.SmoothDamp(Camera.main.orthographicSize, 7f, ref currentVelocity, 0.2f);
        }

        if (SceneManager.GetActiveScene().Equals("Cave"))
        {
            actualSpeed /= 1.4f;
        }
        
        
        // Move Right
        if (Input.GetKey(KeyCode.D))
        {
            //rotate the particle emitter the opposite direction of the player's movement
            ParticleSystem.ShapeModule shape = particleSystem.shape;
            shape.rotation = new Vector3(329.38f, 270, 0.0f);
            // add force to player gameobject
            rigidBody.AddForce(Vector2.right * actualSpeed * Time.deltaTime, ForceMode2D.Impulse);

            gameObject.transform.localScale = new Vector2(Math.Abs(transform.localScale.x), transform.localScale.y);
            // emit particles
            animator.SetBool("isRunning", true);
            doEmitParticles = true;
        }
        else if (!Input.GetKey(KeyCode.A))
        {
            // if no movement keys are being pressed, dont emit particles
            doEmitParticles = false;
        }
        
        
        // Move Left
        if (Input.GetKey(KeyCode.A))
        {
            //rotate the particle emitter the opposite direction of the player's movement
            ParticleSystem.ShapeModule shape = particleSystem.shape;
            shape.rotation = new Vector3(221.8f, 270, 0.0f);
            // add force to player gameobject
            rigidBody.AddForce(Vector2.left * actualSpeed * Time.deltaTime, ForceMode2D.Impulse);
            
            gameObject.transform.localScale = new Vector2(-Math.Abs(transform.localScale.x), transform.localScale.y);
            // emit particles
            animator.SetBool("isRunning", true);
            doEmitParticles = true;
        }
        else if (!Input.GetKey(KeyCode.D))
        {
            // if no movement keys are being pressed, dont emit particles
            doEmitParticles = false;
        }
        
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isRunning", false);
        }
        
        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            // if player's y velocity is about 0, then emit jump particles and add force to gameobject
            if (isAlowedToJump())
            {
                animator.SetTrigger("Jump");
                particleSystemJump.Emit(emitParams, 10);
                if (!SceneManager.GetActiveScene().name.Equals("Cave"))
                {
                    rigidBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                }
                else
                {
                    rigidBody.AddForce(Vector2.up * (jumpSpeed/1.6f), ForceMode2D.Impulse);
                }
                
            }
        }

       
        // if the player is above the ground, then do not emit walk particles
        if (rigidBody.velocity.y != 0.0f)
        {
            doEmitParticles = false;
        }

        if (rigidBody.velocity.magnitude > velocityCap)
        {
            rigidBody.velocity = Vector2.ClampMagnitude(rigidBody.velocity, velocityCap);
        }
        

    }

    private bool isAlowedToJump()
    {
        if (collidingWith)
        {
            if (collidingWith.CompareTag("Wheel"))
            {
                return Math.Abs(Math.Round(rigidBody.velocity.y)) < 3f &&
                       Math.Abs(Math.Round(rigidBody.velocity.y)) > -3f;
            }

            if (collidingWith.CompareTag("FloatingPlatform"))
            {
                return true;
            }
        } 
        return rigidBody.velocity.y < 4f &&
               rigidBody.velocity.y > -4f &&
               collidingWith;
    }

    public void Boost()
    {
        animator.SetTrigger("Jump");
        particleSystemJump.Emit(emitParams, 10);
        rigidBody.AddForce(Vector2.up * boostJumpSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collidingWith = collision.gameObject;
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        collidingWith = null;
    }
}
