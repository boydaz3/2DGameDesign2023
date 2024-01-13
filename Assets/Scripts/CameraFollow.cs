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
        //Allows the player to look up or down by shifting the camera, fixing an issue where jumping
        //would cause the player to lose sight of where they were jumping to
        if(Input.GetButton("LookUp"))
        {
            offset.y = 4;
        }
        else if(Input.GetButton("LookDown"))
        {
            offset.y = 0;
        }
        else
        {
            offset.y = 2;
        }

        //Positions the camera slightly above the player and adds a smooth in/out to the camera movement
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset,
                                                ref currentVelocity, smoothTime);
    }
}
