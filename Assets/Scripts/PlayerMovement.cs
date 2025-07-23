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

    [SerializeField] public float health = 3f;

    [SerializeField] private Animator animator;

    public GameObject mark;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();



    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
       
        Sprint();
        Flip();

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector3(moveSpeed * rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            animator.SetInteger("Movement", 2);
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f, rb.linearVelocity.z);
        }


    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(horizontal * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
        if (horizontal != 0)
        {
            animator.SetInteger("Movement", 1);
        }
        else if (horizontal == 0 && IsGrounded())
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
        bool grounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
        animator.SetInteger("Movement", grounded ? 0 : 2);
        return grounded;
    }


    private void Sprint()
    {
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
        if (other.CompareTag("Hazard"))
        {

            transform.position = respawnPoint.position;
            health -= 1;
            Debug.Log("Player hit a bullet! Health: " + health);


            // Reset velocity to prevent weird physics after teleport
            rb.linearVelocity = Vector3.zero;
        }
    }
    
    
}
