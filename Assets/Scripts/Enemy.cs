using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask playerLayer;
    public GameObject player;
    public Rigidbody2D rb;
    public float robotMoveSpeed;
    public float smoothTime;
    public float detectionRadius;
    private SpriteRenderer sr;
    public Animator animator;
    Vector3 lateTransformPos;
    public float playerOffset;
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D playerHit = Physics2D.Raycast(this.transform.position, player.transform.position - this.transform.position, detectionRadius, playerLayer);
        if (playerHit)
        {
            Vector3 move = Vector3.right * (playerHit.transform.position - this.transform.position).normalized.x * robotMoveSpeed * Time.deltaTime;
            StartCoroutine(MoveSmooth(move));
            sr.flipX = (this.transform.position - playerHit.transform.position).x < 0;
        }
        float horizontalMovement = Mathf.Abs(((this.transform.position-lateTransformPos)/Time.deltaTime).x);
        lateTransformPos = this.transform.position;
        animator.SetFloat("EnemySpeed", horizontalMovement);
    }
    IEnumerator MoveSmooth(Vector3 move)
    {
        var cool = this.transform.position - player.transform.position;
        Debug.Log(cool.magnitude);
        if (cool.magnitude < 0.7f)
        {
            move *= 0.25f;
            this.transform.position+=cool.normalized*playerOffset;
        }
        for (int i = 0; i < smoothTime; i++)
        {
            this.transform.position += move / smoothTime;
            yield return new WaitForSeconds(0.2f);
        }

    }
}
    