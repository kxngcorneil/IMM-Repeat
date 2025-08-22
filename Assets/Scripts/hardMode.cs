using UnityEngine;
using UnityEngine.UI;

public class HardMode : MonoBehaviour
{
    public Toggle hardModeToggle;
    public PlayerMovement player;

    private void Start()
    {

    }

    private void Update()
    {
        if (hardModeToggle.isOn)
        {
            player.health = 10f;
        }
        else
        {
            player.health = 5f;
        }
    }
}