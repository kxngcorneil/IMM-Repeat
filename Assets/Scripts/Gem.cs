using UnityEngine;

public class Gem : MonoBehaviour
{
   private PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                playerMovement.gems += 1;
                Destroy(gameObject);
            }
        }
    }
}
