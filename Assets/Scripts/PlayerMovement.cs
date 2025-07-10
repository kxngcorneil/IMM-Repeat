using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool isFacingRight = true;

    private float horizontal;

    private float vertical;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] public float gems = 0f;

      [SerializeField] public float health = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();


    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f, rb.linearVelocity.z);
        }


    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(horizontal * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
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
        return Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 25f; // Increase speed when sprinting
        }
        else
        {
            moveSpeed = 15f; // Reset to normal speed
        }
    }
}
