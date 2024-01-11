using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
 //allows us to target a specific game object to track its transform values
    public Transform target;

    // creating a new Vector3 to offset the camera from the player position. The last value is z space where we can control the depth of the camera
    public Vector3 offset = new Vector3(0, 2, -10);

    //controls how snappy or slow the camera is in following the player
    public float smoothTime = 0.25f;

    Vector3 currentVelocity;
    // Update is called once per frame
    void LateUpdate()
    {
        //here we are transforming the position of the camera using the smoothDamp method. it needs the curretn position of the object, where it needs to go, its current velocty, and how long it should take to get to
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref currentVelocity, smoothTime);
    }
}
