using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float length, startPos, camStartPos;
    public GameObject cam;
    public float parallax;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        camStartPos = cam.transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        float dist = (cam.transform.position.x - camStartPos) * parallax;
        transform.position = new Vector2(startPos + dist, transform.position.y);
    }
}
