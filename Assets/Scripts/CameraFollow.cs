using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D targetRB;

    public Vector3 offset = new Vector3(0,2-10);
    public float smoothTime = 0.25f;
    private float smoothTime1;
    Vector3 currentVelocity;
    // Start is called before the first frame update
    private void Awake()
    {
        smoothTime1 = smoothTime;
    }
    private void LateUpdate()
    {
        if (targetRB.velocity.magnitude > 1) smoothTime1 = smoothTime / targetRB.velocity.magnitude;
        else smoothTime1 = smoothTime;
        this.transform.position = Vector3.SmoothDamp(this.transform.position, target.position + offset, ref currentVelocity, smoothTime1);
    }
}
