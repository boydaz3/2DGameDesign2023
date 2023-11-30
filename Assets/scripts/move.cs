using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public int testInteger = 5;
    public int anotherInt = 10;
    public string testString = "Hello World";
    public float testFloat = 3.14f;
    public Boolean testBoolean = true;
    // Start is called before the first frame update
    void Start()
    {
        //output Hello World to console
        Debug.Log(testString);

        if (testBoolean) 
        {
                Debug.Log("the boolean is true");
        }else
        {
            Debug.Log("the boolean is false");
        }
        Debug.Log(addNumbers(testInteger, anotherInt));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //custom method to add two integers together
    int addNumbers(int a, int b)
    {
        int sum = a + b;
        return sum;
    }
}
