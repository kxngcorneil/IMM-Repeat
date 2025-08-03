using UnityEngine;

public class Bouncepad : MonoBehaviour
{
    public float bounceForce = 10f;


    private void OnTriggerEnter(Collider other)
    { //if player comes in contact with bounce pad add an upwards force relative to the varaible 
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