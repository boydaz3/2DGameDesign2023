using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float prallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        //getting the x vaule of our starting position
        startPos = transform.position.x;
        //getting the lenght of the sprite
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //how far we have moved from start point
        float dist = (cam.transform.position.x * prallaxEffect);
        //move the spritte based on the location of the camera
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        //removing the background based on how far we have traveled. changing the start position of the backgorund to where we are now
        //tells us how far we have moved realtive to the camera
        float temp = (cam.transform.position.x * (1 - prallaxEffect));

        if(temp > startPos + length){
            startPos += length;
        }else if(temp < startPos - length){
            startPos -= length;
        }
    }
}
