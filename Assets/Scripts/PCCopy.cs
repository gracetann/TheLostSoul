using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCCopy : MonoBehaviour
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
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public bool isEnabled;

    //new
    public LayerMask waterLayer;
    public bool canSwim;
    public float checkWaterRadius;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isEnabled) {
            Move();
            Jump();
            CheckIfGrounded();
        }
    }

    private void Move() {
        float x = Input.GetAxisRaw("Horizontal");

        float moveByX = x * speed;

        rb.velocity = new Vector2(moveByX, rb.velocity.y);
        
        //new
        if (CheckIfWater() && canSwim)
        {
            float y = Input.GetAxisRaw("Vertical");

            float moveByY = y * speed;

            rb.velocity = new Vector2(rb.velocity.x, moveByY);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && (isGrounded || Time.time - lastTimeOnGround < groundedTimeOffset) && !CheckIfWater())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
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

    //new
    private bool CheckIfWater()
    {
        Collider2D colliders = Physics2D.OverlapCircle(transform.position, checkWaterRadius, waterLayer);
        if (colliders != null && colliders.transform.root != transform.root)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ded
    }
}
