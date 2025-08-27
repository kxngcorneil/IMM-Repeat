using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform respawnPoint;
    private float horizontal;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public float gems = 0f;

    [SerializeField] public float health;
    [SerializeField] private Toggle healthToggle; 

    [SerializeField] private Animator animator;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip walkSound;
    [SerializeField] private AudioClip deathSound;

    private Toggle toggle;


    public GameObject mark;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = 5f; 
        
      
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        Sprint();
        Flip();
        noHealth();

        //if player pressed jump button while grounded apply jumpFoce to them so they go up
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector3(moveSpeed * rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            animator.SetInteger("Movement", 2);

            audioSource.PlayOneShot(jumpSound); 
            audioSource.loop = false; 
        }


    }

    private void FixedUpdate()
    {   //if player is moving set out animation movement varaible to 1 indicating that the walking animiation should play
        rb.linearVelocity = new Vector3(horizontal * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
        if (horizontal != 0)
        {
            animator.SetInteger("Movement", 1);

            if (!audioSource.isPlaying && IsGrounded())
            {
                audioSource.PlayOneShot(walkSound);
                audioSource.loop = true; 
            }


        }
        else if (horizontal == 0 && IsGrounded())
        //else if we have no input its set to 0 so we play the idle animation
        {
            animator.SetInteger("Movement", 0);
            audioSource.loop = false; // Stop looping walk sound when idle
            audioSource.Stop(); // Stop walk sound when idle 
        }

    }

    private void Flip()
    {
        if (horizontal > 0f) // Moving right
        {
            transform.localScale = new Vector3(20f, 20f, 20f); // Face right
        }
        else if (horizontal < 0f) // Moving left
        {
            transform.localScale = new Vector3(-20f, 20f, 20f); // Face left
        }
       
    }

    private bool IsGrounded()
    {
        //creat an invisible sphere at th ebottom of the player if its in contact with the ground layer we return the isGrounded boolean as true
        bool grounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
        
        if (grounded)
        {
            animator.SetInteger("Movement", 0);
        }
        else
        {
            animator.SetInteger("Movement", 2);
        }
        
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

    private void noHealth()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("noLives");
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
            audioSource.PlayOneShot(deathSound); 


        
        }
    }
    
  
    
    

    
    
}
