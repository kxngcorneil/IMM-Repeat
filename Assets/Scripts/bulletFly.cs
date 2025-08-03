using UnityEngine;

public class bulletFly : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;

    [SerializeField] private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // The bullet moves to the right according to the speed variable
        rb.linearVelocity = new Vector3(speed, 0, 0);
    }

    void Update()
    {
        // Handle bullet lifetime
        lifetime -= Time.deltaTime;
        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the bullet after hitting the player
            Destroy(gameObject);
        }
    }
}