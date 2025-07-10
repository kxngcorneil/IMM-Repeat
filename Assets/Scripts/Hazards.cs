using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform respawnPoint; // Reference to the respawn point
    
    public PlayerMovement player; // Reference to the PlayerMovement script
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            player.transform.position = respawnPoint.position;
            player.health -= 1; // Decrease player health by 1
            Debug.Log("Player hit a spike! Health: " + player.health);

        }
    }
}