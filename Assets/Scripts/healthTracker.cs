using UnityEngine;

public class healthTracker : MonoBehaviour
{
    public PlayerMovement player;
    public TMPro.TextMeshProUGUI healthText; 

    void Update()
    {
        // Reads the playerHealth variable in the PlayerMovement script and reflects it through the text
        healthText.text = "HEALTH: " + player.health.ToString();
    }
}