using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cacian Rodriguez-Rolon

public class Irradiator : MonoBehaviour
{
    public float IrradiatorSpeed = 5.0f;
    public GameObject[] waypoints;
    private int currentWaypoint;
    private Rigidbody2D rb;
    public Animator animator;
    private CapsuleCollider2D capCol;
    private bool movingForwards;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capCol = GetComponent<CapsuleCollider2D>();
        currentWaypoint = 0;
        movingForwards = true;
    }

    void Update()
    {
        //Determines which waypoint is the waypoint to  currently navigate to
        if(Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < 0.1f)
        {
            //Flips the texture when the enemy reaches end of its path
            if(currentWaypoint == waypoints.Length - 1)
            {
                transform.Rotate(0, 180f, 0);
                movingForwards = true;
            }
            else if(currentWaypoint == 0)
            {
                transform.Rotate(0, 180f, 0);
                movingForwards = false;
            }
            
            //Decrements currentWaypoint if moving from left to right, increments otherwise
            if(movingForwards)
            {
                currentWaypoint--;
            }
            else
            {
                currentWaypoint++;
            }

        }

        //Moves the enemy so long as they haven't been killed
        if(animator.GetBool("isDead") == false)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[currentWaypoint].transform.position, Time.deltaTime * IrradiatorSpeed);
        }
        else
        {
            //Freezes the enemy and disables the capsule collider on death
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            capCol.enabled = false;
        }
        animator.SetFloat("IrradiatorSpeed", rb.velocity[1]);
    }
}
