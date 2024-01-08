using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaz : MonoBehaviour
{
    private float startpros;
    public GameObject can;
    public float prallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startpros = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (can.transform.position.x * prallaxEffect);
        transform.position = new Vector3(startpros + distance, transform.position.y,transform.position.z);
    }
}
