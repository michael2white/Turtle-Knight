using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float dampingTime = 0f;
    private Vector3 velocity = Vector3.zero;

    public float xOffsetThreshold = 138f;
    public float yPosition = -28.5f;
    private float originalYPosition;

    private void Start()
    {
        originalYPosition = transform.position.y;
    }
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);

        // Check if the player has moved past the xOffsetThreshold
        if (target.position.x > xOffsetThreshold)
        {
            desiredPosition.y = yPosition;
        }
        // Check if player has moved back to left of xOffsetThreshold
        else if (target.position.x < xOffsetThreshold)
        {
            desiredPosition.y = originalYPosition;
        }

        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, dampingTime);
        transform.position = smoothedPosition;
    }
}
