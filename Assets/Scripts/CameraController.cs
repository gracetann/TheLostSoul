using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [Header("Camera Following Parameters")]
    [SerializeField]
    private float smoothSpeed = 0.125f;
    public Vector3 offset;

    [Header("Camera Following Edges")]
    [SerializeField]
    private Transform bottomLeft;

    [SerializeField]
    private Transform topRight;

    void FixedUpdate()
    {
        if (player != null) {
            Vector3 position = player.GetComponent<EssenceController>().GetMidlocation();

            float desiredPosX = Mathf.Min(topRight.position.x, Mathf.Max(bottomLeft.position.x, position.x));
            float desiredPosY = Mathf.Min(topRight.position.y, Mathf.Max(bottomLeft.position.y, position.y));

            Vector3 desiredPos = new Vector3(desiredPosX, desiredPosY, position.z);

            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
            transform.position = smoothedPos + offset;
        }
    }
}
