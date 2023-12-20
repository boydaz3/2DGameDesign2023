using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float EnemySpeed = 5.0f;
    public GameObject[] wayPoints;
    private int currentWayPoint;
    public bool canMoveOnX = true;
    //public Rigidbody2D rb;
    
    // Update is called once per frame
    void Update()
    {
        if(canMoveOnX){
            if(Vector2.Distance(wayPoints[currentWayPoint].transform.position, transform.position) < .1f){
                currentWayPoint++;
                transform.Rotate(0, 180f, 0);
                if(currentWayPoint >= wayPoints.Length){
                    currentWayPoint = 0;
                }
            }
            

            transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWayPoint].transform.position, Time.deltaTime * EnemySpeed);
        }

        else{

        }
    }

    public void StopMovementOnX(){
        canMoveOnX = false;
    }
    public void StartMovementOnX(){
        canMoveOnX = true;
    }
}
