using UnityEngine;

public class healthTracker : MonoBehaviour
{
    public PlayerMovement player; // Reference to the PlayerMovement script
    public TMPro.TextMeshProUGUI healthText; // Reference to the TextMeshProUG

    void Update()
    {
        healthText.text = "HEALTH: " + player.health.ToString();
    }

}

