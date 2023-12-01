using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool doMove = false;

    public float enemySpeed = 5.0f;

    public GameObject[] points;

    public int currentPoint;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("changeDoMove", 0.0f, 0.5f);
    }

    void changeDoMove()
    {
        doMove = !doMove;
        if (!doMove)
        {
            animator.SetTrigger("run");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(points[currentPoint].transform.position, transform.position) < 0.1f)
        {
            currentPoint++;
            transform.Rotate(0, 180f, 0);
            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }

        if (doMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[currentPoint].transform.position,
                Time.deltaTime * enemySpeed);
        }
    }

    
}
