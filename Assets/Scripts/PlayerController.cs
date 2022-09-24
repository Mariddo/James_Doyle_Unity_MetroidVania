using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 5.0f;

    [Header("Jumping Attributes")]
    [Tooltip("Jumping and Falling for the betterJump Code")]
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    bool isOnGround;

    bool flipX;

    public Rigidbody2D rb;

    public Transform groundChecker;

    public LayerMask whatIsGround;

    public Animator anim;

    public SpriteRenderer sr;

    public Transform firePosition;
    public BulletBehavior bullet;


    // Start is called before the first frame update
    void Start()
    {
        isOnGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
        BetterJump();

        

        isOnGround = Physics2D.OverlapCircle(groundChecker.position, .2f, whatIsGround);

        SetAnims();
        SetDirection();

        Fire();
    }
    
    void Walk() {

        rb.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
    }

    void Jump() {

        if(Input.GetButtonDown("Jump") && isOnGround) {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    
    void BetterJump() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && Input.GetButtonDown("Jump")) {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }  

        //currentVerticalVelocity = rb.velocity.y; 
    }

    void SetAnims() {

        anim.SetBool("onGround", isOnGround);
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
    }

    void SetDirection() {

        if(rb.velocity.x > 0) {
            transform.localScale = Vector3.one;
        } else if (rb.velocity.x < 0) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        
    }

    void Fire() {
        if(Input.GetButtonDown("Fire1")) {

            anim.SetTrigger("Shoot");
            Instantiate(bullet, firePosition.position, firePosition.rotation).moveDir = new Vector2(transform.localScale.x, 0);
        }

    }
}
