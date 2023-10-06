using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HummingbirdPassive : PlayableObjectController
{
    float time;
    public float interval;
    public int moveBound;
    Vector3 targetPosition;
    bool moving;
    float speed;
    System.Random rand = new System.Random();
    Rigidbody2D rb;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        rb = this.GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        speed = this.GetComponent<HummingbirdController>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<PlayableObjectController>().isEnabled) Move();
    }

    private void Move()
    {
        time += Time.deltaTime;
        if (time >= interval)
        {
            time = 0;
            moving = !moving;
            if (moving) targetPosition = new Vector2(startPosition.x + 0.1f * rand.Next(-moveBound, moveBound), startPosition.y + 0.1f * rand.Next(-moveBound, moveBound));
            if (moving && targetPosition.x - transform.position.x != 0) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * (targetPosition.x - transform.position.x) / Mathf.Abs(targetPosition.x - transform.position.x), transform.localScale.y, transform.localScale.z);
        }
        if (moving) rb.velocity = (targetPosition - transform.position).normalized * speed;
        if (Vector2.Distance(targetPosition, transform.position) < 0.1 || !moving) rb.velocity = Vector2.zero;
    }
}
