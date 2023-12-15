using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    public int baseSpeed;
    public int sprint;
    private int currentSpeed;
    private Vector3 movement = new Vector3(0f, 0f, 0f);
    public int defaultSpeed;
    private int sprintSpeed;
    private bool isSprinting;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = baseSpeed + sprint;
        }
        else
        {
            currentSpeed = baseSpeed;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        {
            if (Input.GetKey(KeyCode.LeftShift)) // while player holds shift he can sprint
            {
                if (!isSprinting)
                {
                    currentSpeed += sprintSpeed;
                    isSprinting = true; // right after we apply the double speed or whatever, we set the bool to true so it can't do it over and over again.
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)) // as soon as he lets go, the bool turns false and the speed is reset
            {
                currentSpeed = defaultSpeed;
                isSprinting = false;
            }
        }

    }

    void FixedUpdate()
    {
        rb.AddForce(movement * currentSpeed);
    }
}