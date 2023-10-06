using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : PlayableObjectController
{
    private Rigidbody2D rb;

    // running settings
    public float speed;
    public float jumpForce;

    // ground edge checking
    public float groundedTimeOffset;
    private float lastTimeOnGround;

    // ground checking
    private bool isGrounded = false;
    public Transform isGroundedChecker;
    public LayerMask groundLayer;

    // animations
    private Vector3 scale;
    public Animator animator;

    //sound effects
    [SerializeField]
    private AudioSource footsteps;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scale = transform.localScale;

        footsteps.Play();
    }

    private void Update()
    {
        if (isEnabled)
        {
            Move();
            Jump();
        }
        else
        {
            footsteps.volume = 0;
            animator.SetBool("isWalking", false);
        }

        CheckIfGrounded();
    }

    private void FixedUpdate()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if (!isGrounded)
        {
            animator.SetBool("isGrounded", false);

            animator.SetFloat("velocityY", 1 * Mathf.Sign(rb.velocity.y));
        }

        if (isGrounded)
        {
            animator.SetBool("isGrounded", true);
            animator.SetFloat("velocityY", 0);
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        animator.SetBool("isWalking", x != 0);

        float moveBy = x * speed;

        if (x > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else if (x < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        if (x != 0 && isGrounded)
        {
            footsteps.volume = 0.3f;
        }
        else {
            footsteps.volume = 0;
        }

        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && (isGrounded || Time.time - lastTimeOnGround < groundedTimeOffset))
        {
            animator.SetTrigger("jumpStart");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, 0.01f, groundLayer);
        if (colliders != null && colliders.transform.root != transform.root)
        {
            isGrounded = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeOnGround = Time.time; 
            }
            isGrounded = false;
        }
    }
}
