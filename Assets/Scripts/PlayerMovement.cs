using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float speed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    private AudioSource audioSource;
    public AudioClip jumpSoundEffect;
    
    private bool hasJumped = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if(input > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (input < 0)
        {
            spriteRenderer.flipX = false;
        }
    
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            if (!hasJumped)
            {
                audioSource.PlayOneShot(jumpSoundEffect);
                hasJumped = true;
            }
                playerRb.velocity = Vector2.up * jumpForce;
        }   

    }

    void FixedUpdate()
    {
        float move = input * speed;
        playerRb.velocity = new Vector2(move, playerRb.velocity.y);

        if (isGrounded)
        {
            hasJumped = false;
        }
    }
}
