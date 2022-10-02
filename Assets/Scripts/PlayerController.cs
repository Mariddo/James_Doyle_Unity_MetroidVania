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

    public Transform firePosition;
    public BulletBehavior bullet;


    [Header("Dashing")]
    public float dashSpeed = 20f;
    public float dashTime = 0.20f;
    private float dashCounter;

    public float dashRecoveryTime = 0.75f;
    private float dashRecoveryCounter;

    [Header ("AfterImage Work")]
    public SpriteRenderer sr;
    public SpriteRenderer afterImage;
    public float afterImageLifetime = 0.25f, afterImageInterval = 0.15f;
    private float afterImageCounter;
    public Color afterImageColor;


    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        isOnGround = false;

        player = GetComponent<Player>();

        AudioManager.instance.PlayLevelMusic();
    }

    // Update is called once per frame
    void Update()
    {

        if(dashCounter <= 0) {
            Walk();
            Jump();
            BetterJump();

            
            SetDirection();
            Fire();
        }
        
        Dash();
        
        SetAnims();

        isOnGround = Physics2D.OverlapCircle(groundChecker.position, .2f, whatIsGround);

        
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
            BulletBehavior bullet1 = Instantiate(bullet, firePosition.position, firePosition.rotation);

            bullet1.moveDir = new Vector2(transform.localScale.x, 0);
            bullet1.damageAmount = player.attackDamage;
        }

    }

    void Dash() {

        if(dashRecoveryCounter > 0) {
            dashRecoveryCounter -= Time.deltaTime;
        }
        
        if(Input.GetButtonDown("Fire2") && dashRecoveryCounter <= 0) {

            dashCounter = dashTime;
            dashRecoveryCounter = dashRecoveryTime;

            ReloadAfterImageInterval();
        }

        if(dashCounter > 0) {

            dashCounter = dashCounter - Time.deltaTime;

            rb.velocity = new Vector2(dashSpeed * transform.localScale.x, rb.velocity.y);

            HandleAfterImages();
        } 
    }

    void ReloadAfterImageInterval() {

        afterImageCounter = afterImageInterval;
    }

    void HandleAfterImages() {

        if(afterImageCounter > 0.0f) {
            afterImageCounter -= Time.deltaTime;
        }

        if(afterImageCounter <= 0.0f) {
            afterImageCounter = afterImageInterval;

            ShowAfterImage();
        }
    }

    void ShowAfterImage() {

            SpriteRenderer image = Instantiate(afterImage, transform.position, transform.rotation);


            image.sprite = sr.sprite;
            image.transform.localScale = transform.localScale;
            image.color = afterImageColor;

            Destroy(image.gameObject, afterImageLifetime);
    }
}
