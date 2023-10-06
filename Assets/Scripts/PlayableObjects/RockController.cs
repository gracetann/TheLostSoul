using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : PlayableObjectController
{
    private Rigidbody2D rb;

    // running settings
    public float speed;
    public float jumpForce;

    // ground edge checking
    public float groundedTimeOffset;
    private float lastTimeOnGround;

    // ground checking
    private bool isGrounded = true;
    public Transform isGroundedChecker;
    public LayerMask groundLayer;

    // animations
    private Vector3 scale;

    //smoke
    public ParticleSystem impactEffect;

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
            if (!isGrounded) {
                impactEffect.gameObject.SetActive(true);
                impactEffect.Stop();
                impactEffect.Play();
            }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ded
    }
}
