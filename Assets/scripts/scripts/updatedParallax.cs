using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updatedParallax : MonoBehaviour
{
    private float Length, startPos
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        //getting the x value of our starting position 
        startPos = transform.position.x;
        //getting the Length of the sprite
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //how far we have moved from start point
        float dist = (cam.transform.position.x * parallaxEffect);
        //move the 
    }
}
