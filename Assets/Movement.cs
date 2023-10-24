using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public ParticleSystem particleSystem;
    public ParticleSystem particleSystemJump;
    private ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
    private bool doEmitParticles = false;
    
    public float speed = 6f;
    public float jumpSpeed = 5f;
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        particleSystem.Stop();
        particleSystemJump.Stop();
        
        InvokeRepeating("emitParticles", 0, 0.1f);
        
    }


    private void emitParticles()
    {
        if (doEmitParticles)
        {
            particleSystem.Emit(emitParams, 2);
        }
        
    }
    
    void Update()
    {
        // Move Right
        if (Input.GetKey(KeyCode.D))
        {
            ParticleSystem.ShapeModule shape = particleSystem.shape;
            shape.rotation = new Vector3(329.38f, 270, 0.0f);
            rigidBody.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
            doEmitParticles = true;
        }
        else if (!Input.GetKey(KeyCode.A))
        {
            doEmitParticles = false;
        }
        
        
        // Move Left
        if (Input.GetKey(KeyCode.A))
        {
            ParticleSystem.ShapeModule shape = particleSystem.shape;
            shape.rotation = new Vector3(221.8f, 270, 0.0f);
            rigidBody.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
            doEmitParticles = true;
        }
        else if (!Input.GetKey(KeyCode.D))
        {
            doEmitParticles = false;
        }
        
        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (rigidBody.velocity.y == 0f)
            {
                particleSystemJump.Emit(emitParams, 10);
                rigidBody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            }
        }
        
        // if the player is above the ground, then do not emit walk particles
        if (rigidBody.velocity.y != 0.0f)
        {
            doEmitParticles = false;
        }

    }
}
