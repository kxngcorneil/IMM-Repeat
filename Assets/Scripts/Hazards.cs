using UnityEngine;

public class Hazards : MonoBehaviour
{
    public Transform respawnPoint;
    public PlayerMovement player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Move the player back to the respawn point
            player.transform.position = respawnPoint.position;
            Debug.Log("been hit, health: " + player.health);
        }
    }
}