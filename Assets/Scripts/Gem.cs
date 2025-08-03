using UnityEngine;

public class Gem : MonoBehaviour
{
   private PlayerMovement playerMovement;
    void Start()
    {
        //calling the playermovement script 
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if player comes in contact with a gem increase the gemCounter varaible in the playerMovement script by 1 and destroy the gem object
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                playerMovement.gems += 1;
                Destroy(gameObject);
            }
        }
    }
}
