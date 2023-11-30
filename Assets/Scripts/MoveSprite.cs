using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSprite : MonoBehaviour
{
    private SpriteRenderer sr;

    private float moveX;

    public Rigidbody2D rb;
    public float moveSpeed;
    public float moveSpeedAir;
    public float jumpHeight;
    public LayerMask groundLayer;
    public TrailRenderer trail;
    private RaycastHit2D groundHit;
    private RaycastHit2D slopeHit;
    private RaycastHit2D wallHit;

    private bool isGrounded;
    private bool isJumping;
    private bool isWallSliding;
    private bool isDashing;
    private bool isDashing1 = false;

    private Vector3 wallPoint;

    public Animator animator;
    private float horizontalMovement = 0f;

    public GameObject dashPartic;

    public AudioSource playerAudio;
    public AudioClip jump;
    public AudioClip dash;
    public AudioClip land;
    public AudioClip walk;

    // Update is called once per frame
    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        trail.emitting = false;
    }
    void FixedUpdate()
    {
        GroundCheck();
        Move();
        Animate();
        WallSlide();
        if (Input.GetKeyUp(KeyCode.Space)) isJumping = false;
        else if (Input.GetKey(KeyCode.Space) && (isGrounded || slopeHit || isWallSliding) && !isJumping) Jump();
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing&&!isGrounded&&!isWallSliding&&!slopeHit&&moveX!=0) StartCoroutine(Dash());
        
    }
    void GroundCheck()
    {
        groundHit = Physics2D.Raycast(new Vector3(-0.2f,-0.6f)+this.transform.position, Vector3.right, 0.4f, groundLayer);
        slopeHit = Physics2D.BoxCast(new Vector3(0,-0.35f,0)+this.transform.position,new Vector2(0.65f,0.2f),0,Vector2.zero,Mathf.Infinity,groundLayer);
        wallHit = Physics2D.BoxCast(new Vector3(0,0.05f,0) + this.transform.position, new Vector2(0.75f,0.55f), 0, Vector2.zero, Mathf.Infinity, groundLayer);
        isGrounded = groundHit||slopeHit;
        isWallSliding = wallHit;
        isDashing = isDashing&&!(isGrounded||isWallSliding||slopeHit);
    }
    private void Move()
    {
        moveX = Input.GetAxis("Horizontal");
        if (isGrounded)
        {
            rb.velocity = new Vector3(moveX * moveSpeed, rb.velocity.y, 0);
        }
        else if (slopeHit)
        {
            Debug.DrawRay(slopeHit.point, slopeHit.normal, Color.red);
            rb.velocity = moveX * moveSpeed * -Vector2.Perpendicular(slopeHit.normal) / 1.41f;
        }
        else if (isWallSliding)
        {
            rb.velocity += wallPoint.x * Vector2.right;
            rb.velocity /= 1.02f;
        }
        else rb.AddForce(moveX * transform.right * moveSpeedAir - (new Vector3(rb.velocity.x, 0) * 2.4f));
        if (isGrounded && Mathf.Abs(moveX) > 0.1f)
        {
            playerAudio.clip = walk;
            playerAudio.loop = true;
            playerAudio.pitch = 0.5f*Mathf.Sqrt(rb.velocity.magnitude);
            if(!playerAudio.isPlaying)playerAudio.Play();
        }
        else
        {
            playerAudio.pitch = 1;
            playerAudio.loop = false;
        }
    }
    private void Animate()
    {
        horizontalMovement = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("PlayerSpeed", horizontalMovement);
        animator.SetBool("IsJumping", !isGrounded);
        animator.SetBool("IsWallSliding", isWallSliding);
        animator.SetBool("IsSlope", slopeHit);
        animator.SetBool("IsDashing", isDashing1);
        if (moveX != 0 || wallPoint.x != 0) sr.flipX = moveX + (wallPoint.x * 10) < 0;
    }
    private void Jump()
    {
            if (isWallSliding)
            {
                rb.velocity = (jumpHeight+rb.velocity.y) * Vector2.up - (new Vector2(wallPoint.x,0) * 15);
                sr.flipX = !sr.flipX;
            }
            else
            {
                rb.velocity += (jumpHeight-rb.velocity.y) * Vector2.up - (new Vector2(wallPoint.x,0) * 15);
            }
            isJumping = true;
            playerAudio.clip = jump;
            playerAudio.Play();
    }
    private void WallSlide()
    {
        if(isWallSliding)
        {
            wallPoint = wallHit.point;
            wallPoint -= this.transform.position;
        }
        else wallPoint = Vector3.zero;
    }
    IEnumerator Dash()
    {
        isDashing = true;
        isDashing1 = true;
        rb.velocity = new Vector2(moveSpeed * 3 * moveX,1f);
        sr.color = new Vector4(1,1,1,0.3f);
        trail.emitting = true;
        GameObject dashPartic1 = Instantiate(dashPartic,this.transform.position,this.transform.rotation);
        Destroy(dashPartic1, dashPartic1.GetComponent<ParticleSystem>().startLifetime);
        playerAudio.clip = dash;
        playerAudio.Play();
        yield return new WaitForSeconds(0.2f);
        isDashing1 = false;
        trail.emitting = false;
        sr.color = new Vector4(1, 1, 1, 1);
        if (isGrounded || isWallSliding || slopeHit)
        {
            yield return null;
            isDashing = true;
        }
        rb.velocity = new Vector2(moveSpeed*moveX, rb.velocity.y);
    }
}