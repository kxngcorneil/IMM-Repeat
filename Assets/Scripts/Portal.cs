using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public PlayerMovement player;
    [SerializeField] private Transform destination;
    private bool usePortal = false; 

    void Update()
    {
        teleport();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            usePortal = true; 
            player.mark.SetActive(true); // Show the portal marker when player is near
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            usePortal = false; 
            player.mark.SetActive(false); // Hide the portal marker when player is not near
        }
    }

    private void teleport()
    {
        if (usePortal && Input.GetKeyDown(KeyCode.E)) 
        {

            player.transform.position = destination.position;



        }
    }

}

