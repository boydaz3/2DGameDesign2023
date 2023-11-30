using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask playerLayer;
    public GameObject player;
    public CharacterController cc;
    public float robotMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D playerHit = Physics2D.Raycast(this.transform.position,player.transform.position-this.transform.position,3,playerLayer);
        if (playerHit)
        {
            cc.Move(Vector2.right * (playerHit.point.x-this.transform.position.x)*Time.deltaTime*robotMoveSpeed);
            cc.Move(Mathf.Pow(9.84, 2));
        }
    }
}
