using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public Vector2 destination;
    bool reached = false;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, destination) < 0.1) reached = true;
        if (!reached)
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        }
    }
}
