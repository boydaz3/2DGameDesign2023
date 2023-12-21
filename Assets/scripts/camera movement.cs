using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovementscript : MonoBehaviour
{
  //allows us to target a specefic gme object to trask its transform values
   public Transform target;

   //creating a new vector to offset the camera from the player position. the last value is z where we can control the depth of the camera
   public Vector3 offset = new Vector3(0, 2, -10);
   
   
   public float smoothTime = 0.25f;

   Vector3 currentVilcoty;
    // Update is called once per frame
    void LateUpdate()
    {
        //here we are transforming the position of the camera using the smoothD method. it nees the current position of the object, where it needs to go, to its current vilcoty, and how long it should take to get to
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref currentVilcoty, smoothTime);
    }
}
