using UnityEngine;

public class healthTracker : MonoBehaviour
{
    public PlayerMovement player; // Reference to the PlayerMovement script
    public TMPro.TextMeshProUGUI healthText; // Reference to the TextMeshProUGUI

    void Update()
    {
        // Reads the playerHealth variable in the PlayerMovement script and reflects it through the text
        healthText.text = "HEALTH: " + player.health.ToString();
    }
}