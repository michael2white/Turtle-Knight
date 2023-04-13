using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float attackRange = 2f;
    private Transform player;
    private bool isFacingLeft = true;
    private Rigidbody2D rb;
    public float detectionRange = 50f;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("TurtleKnight_Pixel").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            //attack player will go here
        }
        else if (distanceToPlayer <= detectionRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

            if (direction.x < 0 && !isFacingLeft)
            {
                Flip();
            }
            else if (direction.x > 0 && isFacingLeft)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        transform.Rotate(0f, 180f, 0f);
    }
}
