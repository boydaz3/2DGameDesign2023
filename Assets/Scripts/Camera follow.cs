using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    //allows us to target a specicfic game object to track its transform values
    public Transform target;

    //creating a new vector3 to offset the camer from the player position 
    public Vector3 offset = new Vector3(0, 2, -10);
    

    public float smoothTime = 0.25f;

    Vector3 currentVelocity;
    // Update is called once per frame
    void LateUpdate()
    {
        //here we sare transforming the position of the camera using the SmoothDamp method
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref currentVelocity, smoothTime);
    }
}
