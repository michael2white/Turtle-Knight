using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float leftLimit = 0f;
    public float rightLimit = 5f;
    public float speed = 2f;

    private int direction = 1;

    void Start()
    {
        // Initialize the platform's position to the left limit
        transform.position = new Vector3(leftLimit, transform.position.y, transform.position.z);
    }

    void Update()
    {
        // Move the platform left and right between the left and right limits
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0f, 0f);

        if (transform.position.x >= rightLimit)
        {
            // Change direction to move left
            direction = -1;
        }
        else if (transform.position.x <= leftLimit)
        {
            // Change direction to move right
            direction = 1;
        }
    }
}