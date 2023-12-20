using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    private float startPos;
    public GameObject cam;
    public float parralaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x; 
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (cam.transform.position.x * parralaxEffect);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
