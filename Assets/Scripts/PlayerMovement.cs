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
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal"); // Horizontal Movement Code
        if(input > 0)
        {
            spriteRenderer.flipX = true;
            GetComponent<BoxCollider2D>().offset = new Vector2(-Mathf.Abs(GetComponent<BoxCollider2D>().offset.x), GetComponent<BoxCollider2D>().offset.y); //flips box collider with player
            feetPosition.localPosition = new Vector3(-Mathf.Abs(feetPosition.localPosition.x), feetPosition.localPosition.y, feetPosition.localPosition.z); //flips feet position with player
        }
        else if (input < 0)
        {
            spriteRenderer.flipX = false;
            GetComponent<BoxCollider2D>().offset = new Vector2(Mathf.Abs(GetComponent<BoxCollider2D>().offset.x), GetComponent<BoxCollider2D>().offset.y);
            feetPosition.localPosition = new Vector3(Mathf.Abs(feetPosition.localPosition.x), feetPosition.localPosition.y, feetPosition.localPosition.z);
        }
    
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (isGrounded == true && Input.GetButtonDown("Jump")) //Jump Code
        {
            if (!hasJumped)
            {
                audioSource.PlayOneShot(jumpSoundEffect);
                hasJumped = true;
            }
                playerRb.velocity = Vector2.up * jumpForce;
        }   

        if (input > 0f) // Animations
        {
            anim.SetBool("running", true);
        }
        else if (input < 0f)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }

    }

    void FixedUpdate()
    {
        float move = input * speed; //Only jumps if feet on the ground
        playerRb.velocity = new Vector2(move, playerRb.velocity.y); 

        if (isGrounded)
        {
            hasJumped = false;
        }
    }
}
