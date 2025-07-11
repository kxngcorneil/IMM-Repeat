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
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            usePortal = false; 
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

