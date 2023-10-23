using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int testInt = 5;
    public int anotherInt = 10;
    public string testStr = "Hello World!";
    public float testFloat = 3.14f;
    public bool testBool = true;

    private Rigidbody2D rigidBody;
    private ParticleSystem particleSystem;
    private ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams();
    
    public float speed = 6f;
    void Start()
    {
        Debug.Log(testStr);

        // Didn't use "if statement" because this is smaller.
        Debug.Log(testBool?"the boolean is true":"the boolean is false");
        
        Debug.Log(add(testInt, anotherInt));

        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        particleSystem.Stop();
    }

    private int add(int a, int b)
    {
        int sum = a + b;
        return sum;
    }
    
    void Update()
    {
        // Bonus: I coded an actual movement script, unlike the tutorial :(
        
        // Move Right
        if (Input.GetKey(KeyCode.D))
        {
            ParticleSystem.ShapeModule shape = particleSystem.shape;
            shape.rotation = new Vector3(329.38f, 270, 0.0f);
            rigidBody.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
            particleSystem.Emit(emitParams, Mathf.RoundToInt(27*Time.deltaTime));
        }
        
        
        // Move Left
        if (Input.GetKey(KeyCode.A))
        {
            ParticleSystem.ShapeModule shape = particleSystem.shape;
            shape.rotation = new Vector3(221.8f, 270, 0.0f);
            rigidBody.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
            particleSystem.Emit(emitParams, Mathf.RoundToInt(27 * Time.deltaTime));
        }
        
        
        
        
    }
}
