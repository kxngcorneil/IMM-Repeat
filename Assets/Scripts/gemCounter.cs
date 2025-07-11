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
            //Sets whatever coinCounter text is to the number of gems gems in the player script
            coinCounter.text = player.gems.ToString();
        }
    }
}
