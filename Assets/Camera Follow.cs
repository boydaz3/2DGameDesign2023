using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Allows us to target a specific game object to track its transform values
    public Transform target;

    // Creating a new Vector3 to offset the camera from the player's position. The last value is z-space where we can control the depth of the camera.
    public Vector3 offset = new Vector3(0, 2, -10);

    // Controls how snappy or slow the camera is in following the player.
    public float smoothTime = 0.25f;

    private Vector3 currentVelocity;

    // LateUpdate is called once per frame
    void LateUpdate()
    {
        // Here we are transforming the position of the camera using the SmoothDamp method.
        // It needs the current position of the object, where it needs to go, its current velocity, and how long it should take to get there.
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref currentVelocity, smoothTime);
    }
}