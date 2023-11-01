// Suvan Mangamuri
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    // these variables are set in the Unity Editor
    public ParticleSystem particleSystem;
    public ParticleSystem particleSystemJump;
    
    private ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
    private bool doEmitParticles = false;
    
    public float speed = 7f;
    public float jumpSpeed = 6.5f;
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
        
        // Move Right
        if (Input.GetKey(KeyCode.D))
        {
            //rotate the particle emitter the opposite direction of the player's movement
            ParticleSystem.ShapeModule shape = particleSystem.shape;
            shape.rotation = new Vector3(329.38f, 270, 0.0f);
            // add force to player gameobject
            rigidBody.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
            // emit particles
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
            rigidBody.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
            // emit particles
            doEmitParticles = true;
        }
        else if (!Input.GetKey(KeyCode.D))
        {
            // if no movement keys are being pressed, dont emit particles
            doEmitParticles = false;
        }
        
        // Jump
        if (Input.GetButtonDown("Jump"))
        {
            // if player's y velocity is about 0, then emit jump particles and add force to gameobject
            if (Math.Abs(Math.Round(rigidBody.velocity.y)) == 0f)
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
