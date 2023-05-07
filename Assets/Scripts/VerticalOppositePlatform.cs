
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalOppositePlatform : MonoBehaviour
{
    public float topLimit = 5f;
    public float bottomLimit = 0f;
    public float speed = 2f;

    private int direction = 1;

    void Start()
    {
        // Initialize the platform's position to the bottom limit
        transform.position = new Vector3(transform.position.x, bottomLimit, transform.position.z);
    }

    void Update()
    {
        // Move the platform up and down between the top and bottom limits
        transform.position += new Vector3(0f, speed * direction * Time.deltaTime, 0f);

        if (transform.position.y <= topLimit)
        {
            // Change direction to move down
            direction = 1;
        }
        else if (transform.position.y >= bottomLimit)
        {
            // Change direction to move up
            direction = -1;
        }
    }
}