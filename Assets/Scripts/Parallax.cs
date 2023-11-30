using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Par : MonoBehaviour
{
    // Start is called before the first frame update
    private float startPos;
    public GameObject cam;
    public float prallaxEffect;
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (cam.transform.position.x * prallaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.x);
    }
}
