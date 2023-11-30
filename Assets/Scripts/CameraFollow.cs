using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //allows us to follow a specific game object to track its transform values
    public Transform target;

    //Creating a new Vector3 to offset the camera from the player position. The last value is z space where we can control the depth of the camera.
    public Vector3 offset = new Vector3(0, 2, -10);
    // Update is called once per frame

    //Controls how snappy or slow the camera is following the player
    public float smoothTime = 0.25f;

    Vector3 currentVelocity;
    void LateUpdate()
    {
        //here we are transforming the position of the camera using the smoothdamp method. It needs the current position of the object, where it needs to go, it's current velocity, and how long it should take to get there.
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref currentVelocity, smoothTime);
    }
}
