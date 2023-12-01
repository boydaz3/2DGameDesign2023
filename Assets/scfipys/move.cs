using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class move : MonoBehaviour
{
    public int testInteger = 5;
    public string testString = "Hello World";
    public float testfloat = 3.14f;
    public bool testBoolean = true;
    // Start is called before the first frame update
    void Start()
    {
        //output Hello World to console 
        Debug.Log(testString);

        if (testBoolean) {
            Debug.Log("the boolean is true");
        } else {
            Debug.Log("the boolean is false");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}