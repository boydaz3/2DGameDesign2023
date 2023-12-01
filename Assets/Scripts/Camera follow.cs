using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    //allows us to target a specific game object to track its transform values
    public Transform target;

    //creating a new vector3 to offset camera from the player position. the last value is z space where we can control the depth of the camera
    public Vector3 offset = new Vector3(0, 2, -10);


    public float smoothTime = 0.25f;

    Vector3 currentVelocity;
    // Update is called once per frame
    void LateUpdate()
    {
        //here we are transforming the position of the camera using the smoothDamp method.it needs to current positon, where it needs to go, its current velcoidty, and how long it should take to get to the new location.
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref currentVelocity, smoothTime);
    }
}
