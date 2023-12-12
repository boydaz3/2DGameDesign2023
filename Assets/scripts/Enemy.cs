using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemySpeed = 5.0f;
    public GameObject[] WayPoints;
    private int currentWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        if(Vector2.Distance(WayPoints[currentWayPoint].transform.position, transform.position) < .1f)
        {
            currentWayPoint++;
            if(currentWayPoint >= WayPoints.Length)
            {
                currentWayPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, WayPoints[currentWayPoint].transform.position, Time.deltaTime * EnemySpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
