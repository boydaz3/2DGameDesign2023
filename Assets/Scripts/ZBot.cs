using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cacian Rodriguez-Rolon

public class ZBot : MonoBehaviour
{
    public float ZBotSpeed = 5.0f;
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
        if(waypoints.Length > 0)
        {
            //Determines which waypoint is the waypoint to currently navigate to
            if(Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < 0.1f)
            {
                //Flips the texture when the enemy reaches end of its path
                if(currentWaypoint == waypoints.Length - 1)
                {
                    transform.Rotate(0, 180f, 0);
                    movingForwards = false;
                }
                else if(currentWaypoint == 0)
                {
                    transform.Rotate(0, 180f, 0);
                    movingForwards = true;
                }
                
                //Increments currentWaypoint if moving from left to right, increments otherwise
                if(movingForwards)
                {
                    currentWaypoint++;
                }
                else
                {
                    currentWaypoint--;
                }

            }

            //Moves the enemy so long as they haven't been killed
            if(animator.GetBool("isDead") == false)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                waypoints[currentWaypoint].transform.position, Time.deltaTime * ZBotSpeed);
            }
            animator.SetFloat("ZBotSpeed", Mathf.Abs(rb.velocity.y));
        }
    }
}
