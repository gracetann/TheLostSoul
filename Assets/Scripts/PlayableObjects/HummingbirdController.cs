using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HummingbirdController : PlayableObjectController
{
    private Rigidbody2D rb;

    // running settings
    public float speed;

    // animations
    private Vector3 scale;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        scale = transform.localScale;
    }

    private void Update()
    {
        if (this.GetComponent<PlayableObjectController>().isEnabled)
        {
            Move();
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float moveByX = x * speed;
        float moveByY = y * speed;

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

        rb.velocity = new Vector2(moveByX, moveByY);
    }
}