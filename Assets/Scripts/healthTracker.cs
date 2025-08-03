using UnityEngine;

public class healthTracker : MonoBehaviour
{
    public PlayerMovement player; // Reference to the PlayerMovement script
    public TMPro.TextMeshProUGUI healthText; // Reference to the TextMeshProUG

    void Update()
    {
        //reads playerHealth variable in the playerMovement script and reflect it through text
        healthText.text = "HEALTH: " + player.health.ToString();
    }

}

