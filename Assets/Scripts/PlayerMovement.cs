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
    private int numJumps = 0;
    private Animator anim;

    public bool canMove = true; //Added variable to enable/disable player movement
    private enum MovementState { idle, running, jumping, falling, dropWeapon } //Animator numbers
    public ParticleSystem jumpParticles;

    public float dashDistance;
    private float dashTime;
    private float lastInputTime;
    private bool isDashing = false;
    private Vector2 lastTapDirection = Vector2.zero;
    


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        anim = GetComponent<Animator>();
        jumpParticles = GetComponent<ParticleSystem>(); 

        lastTapDirection = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        MovementState state;

        if(!canMove) //Exit if player movement is disabled
        {
            return;
        }

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
                jumpParticles.Play();
                audioSource.PlayOneShot(jumpSoundEffect);
                hasJumped = true;
                numJumps = 1;
            }
                playerRb.velocity = Vector2.up * jumpForce;
        }
        else if (numJumps < 1 && Input.GetButtonDown("Jump"))
        {
            jumpParticles.Play();
            audioSource.PlayOneShot(jumpSoundEffect);
            numJumps++;
            playerRb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(Dash());
            lastInputTime = -1f;
        }
        else if (Input.GetButtonDown("Horizontal"))
        {
            lastInputTime = Time.time;
        }   

        if (input > 0f) // Animations
        {
            state = MovementState.running;
        }
        else if (input < 0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (playerRb.velocity.y > 0)
        {
            state = MovementState.jumping;
        }
        else if (playerRb.velocity.y < 0)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);

    }

    private IEnumerator Dash()
    {
        isDashing = true;
        
        MovementState state;

        float startTime = Time.time;
        float elapsedTime = 0f;
        float dashDuration = 0.5f; // adjust this as needed
        Vector2 dashDirection = new Vector2(input, 0f).normalized;
        float dashSpeed = 200f;

        
        
            while (elapsedTime < dashDuration && !hasJumped)
            {
                //Moves the Player
                playerRb.MovePosition((Vector2)transform.position + (dashDirection * dashSpeed * Time.deltaTime));

                //Sets dash animation
                state = MovementState.running;
                anim.SetInteger("state", (int)state);

                elapsedTime = Time.time - startTime;
                yield return null;
            }
        

        lastTapDirection = dashDirection;
        isDashing = false;
    }

    void FixedUpdate()
    {
        float move = input * speed; //Only jumps if feet on the ground
        playerRb.velocity = new Vector2(move, playerRb.velocity.y); 

        if (isGrounded)
        {
            hasJumped = false;
            numJumps = 0;
        }

        if (!isDashing)
        {
            playerRb.velocity = new Vector2(move, playerRb.velocity.y);
        }
    }
}
