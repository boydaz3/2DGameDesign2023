using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //allows us to target a specfic game object to track its transform values;
    public Transform target;
    
    //Creating a new vector3 to offset th camera from the player position. the last value is z space where we can control depth of the camera
    public Vector3 offset = new Vector3 (0, 2, -10);

    //controls how snappy or slow the camera is in following the player
public float smoothTime = 0.25f;

Vector3 currentVelocity;
//update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref currentVelocity, smoothTime);
    }
}
