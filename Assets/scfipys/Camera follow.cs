using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    //allows us to target a sopecififc game object to track it
    public Transform target;

    //creating a new vector 3 to offset the camera from the player position the last value is 2 spaces where we can control the depgth of camera
    public Vector3 offset = new Vector3(0, 2, -10);


    public float smoothTime = 0.25f;

    Vector3 currentVelocity;

    // Update is called once per frame
    void LateUpdate()
    {
        //here we are transforming the position of the camera using sthoothdamp method 

        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref currentVelocity, smoothTime);
    }
}
