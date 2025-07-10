using UnityEngine;

public class Bouncepad : MonoBehaviour
{
    public float bounceForce = 10f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, bounceForce, rb.linearVelocity.z);
            }

        }
    }
}