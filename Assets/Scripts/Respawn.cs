using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Cacian Rodriguez-Rolon

public class NewBehaviourScript : MonoBehaviour
{
    //Detects collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks if the collision is with an Enemy object
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //Restarts the level, or in this case game, if the collision was not with the enemys head
            if(!isStomping(collision))
            {
                Restart();
            }
        }
    }

    //Reloads the active scene when called, effectively restarting the level
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /*
    Let's be honest this is shorter while still being easily understandable
    Checks whether the collision was with the enemys head by checking the height of both objects
    In hindsight there may be a better way to do this... It's late however
    */
    private bool isStomping(Collision2D collision)
    {
        return transform.position.y > collision.gameObject.transform.position.y;
    }
}
