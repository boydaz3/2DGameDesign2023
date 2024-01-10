using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavePressurePlate : MonoBehaviour
{
    private bool isActivated = false;
    public Animator Animator;
    public GameObject Wheel;

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            Wheel.transform.Rotate(new Vector3(0, 0, -30f * Time.deltaTime));
        }

        Wheel.GetComponent<Rigidbody2D>().centerOfMass = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Wheel.GetComponent<Rigidbody2D>().freezeRotation = false;
        isActivated = true;
        Animator.SetTrigger("ColliderEnter");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isActivated = false;
        Animator.SetTrigger("ColliderExit");
    }
}
