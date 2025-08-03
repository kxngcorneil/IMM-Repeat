using UnityEngine;
using TMPro;

public class coinCount : MonoBehaviour
{
    public PlayerMovement player;
    public TextMeshProUGUI coinCounter;

    void Update()
    {
        if (player != null && coinCounter != null)
        {
            // Sets the coinCounter text to display the number of gems from the PlayerMovement script
            coinCounter.text = "GEMS: " + player.gems.ToString();
        }
    }
}