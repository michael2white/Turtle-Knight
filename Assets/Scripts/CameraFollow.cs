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

    public float xOffsetThreshold = 140f;
    public float yPosition = -28.5f;
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);

        // Check if the player has moved past the xOffsetThreshold
        if (target.position.x > xOffsetThreshold)
        {
            desiredPosition.y = yPosition;
        }

        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, dampingTime);
        transform.position = smoothedPosition;
    }
}
