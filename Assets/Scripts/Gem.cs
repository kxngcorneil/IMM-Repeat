using UnityEngine;

public class Gem : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gemCollect;
 

    void Start()
    {
        // Calling the PlayerMovement script
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // If the player comes in contact with a gem, increase the gemCounter variable in the PlayerMovement script by 1 and destroy the gem object
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                playerMovement.gems += 1;
                audioSource.PlayOneShot(gemCollect);
                Destroy(gameObject);
            }
        }
    }
}