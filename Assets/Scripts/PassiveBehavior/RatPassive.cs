using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatPassive : PlayableObjectController
{
    float time;
    public float interval;
    public float passiveSpeed;
    System.Random rand = new System.Random();
    Rigidbody2D rb;
    int temp;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        rb = this.GetComponent<Rigidbody2D>();
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
            temp = rand.Next(2);
        }
        if (temp == 0) rb.velocity = new Vector2(passiveSpeed, rb.velocity.y);
        else rb.velocity = new Vector2(-passiveSpeed, rb.velocity.y);
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * rb.velocity.x / Mathf.Abs(rb.velocity.x), transform.localScale.y, transform.localScale.z);
    }
}
