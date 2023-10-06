using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulBodyController : PlayableObjectController
{
    public Rigidbody2D rb;

    // running settings
    public float speed;
    public float jumpForce;

    // ground edge checking
    public float groundedTimeOffset;
    private float lastTimeOnGround;

    // ground checking
    public bool isGrounded = false;
    public Transform isGroundedChecker;
    public LayerMask groundLayer;

    // animations
    private Vector3 scale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scale = transform.localScale;
    }

    private void Update()
    {
        if (isEnabled)
        {
            Move();
            Jump();
        }
        CheckIfGrounded();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");

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

        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && (isGrounded || Time.time - lastTimeOnGround < groundedTimeOffset))
        {
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
