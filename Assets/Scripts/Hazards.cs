using UnityEngine;

public class Hazards : MonoBehaviour
{
    public Transform respawnPoint; // Reference to the respawn point
    public PlayerMovement player;  // Reference to the PlayerMovement script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Move the player back to the respawn point
            player.transform.position = respawnPoint.position;

            // Decrease player health by 1
            player.health -= 1;

            Debug.Log("Player hit a spike! Health: " + player.health);
        }
    }
}