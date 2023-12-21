using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cacian Rodriguez-Rolon

public class CameraFollow : MonoBehaviour
{
    //Creation of variables
    public Transform target;
    public Vector3 offset =  new Vector3(0,2,-10);
    public float smoothTime = 0.125f;
    Vector3 currentVelocity;

    //LateUpdate is the last method called per frame
    void LateUpdate()
    {
        //Positions the camera slightly above the player and adds a smooth in/out to the camera movement
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset,
                                                ref currentVelocity, smoothTime);
    }
}
