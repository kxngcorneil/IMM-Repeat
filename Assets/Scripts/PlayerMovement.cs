using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool isFacingRight = true;

    public Transform respawnPoint; // Reference to the respawn point
    private float horizontal;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public float gems = 0f;

    [SerializeField] public float health = 5f;

    [SerializeField] private Animator animator;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioClip deathSound;


    public GameObject mark;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = 5f; // Initialize health



    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
       
        Sprint();
        Flip();

        //if player pressed jump button while grounded apply jumpFoce to them so they go up
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector3(moveSpeed * rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            animator.SetInteger("Movement", 2);

            audioSource.PlayOneShot(jumpSound); // Play jump sound
            audioSource.loop = false; // Set the audio source to not loop for jump sound
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f, rb.linearVelocity.z);
        }


    }

    private void FixedUpdate()
    {   //if player is moving (so our horizontal input is -1 or 1) set out animation movement varaible to 1 indicating that the walking animiation should play
        rb.linearVelocity = new Vector3(horizontal * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
        if (horizontal != 0)
        {
            animator.SetInteger("Movement", 1);

            while (!audioSource.isPlaying && IsGrounded())
            {
                audioSource.PlayOneShot(walkSound); // Play walk sound if not already playing
                audioSource.loop = true; // Set the audio source to loop for walk sound
            }
    
                
        }
        else if (horizontal == 0 && IsGrounded())
        //else if we have no input its set to 0 so we play the idle animation
        {
            animator.SetInteger("Movement", 0);
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        //creat an invisible sphere at th ebottom of the player if its in contact with the ground layer we return the isGrounded boolean as true
        bool grounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
        animator.SetInteger("Movement", grounded ? 0 : 2);
        return grounded;
    }


    private void Sprint()
    {
        //if player is grounded and holds shift speed increases making them sprint 
        if (Input.GetKey(KeyCode.LeftShift) && IsGrounded())
        {
            moveSpeed = 25f; // Increase speed when sprinting
        }
        else
        {
            moveSpeed = 15f; // Reset to normal speed
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //take one health away from player if they hit something with the hazard varaible
        if (other.CompareTag("Hazard"))
        {


            transform.position = respawnPoint.position;
            health -= 1;
            Debug.Log("Player hit a bullet! Health: " + health);
            audioSource.PlayOneShot(deathSound); // Play death sound 


            // Reset velocity to prevent weird physics after teleport
        //    rb.linearVelocity = Vector3.zero;
        }
    }
    
    
}
