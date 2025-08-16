using UnityEngine;

public class Bouncepad : MonoBehaviour
{
    public float bounceForce = 10f;
      [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bounceSound;

    private void OnTriggerEnter(Collider other)
    {
        // If the player comes in contact with the bounce pad, add an upward force relative to the variable
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, bounceForce, rb.linearVelocity.z);
                audioSource.PlayOneShot(bounceSound);
            }
        }
    }
}