using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gemCollect;
 

    void Start()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Get the PlayerMovement by determining the script
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            
            // If the player comes in contact with a gem, increase the gemCounter variable in the PlayerMovement script by 1 and destroy the gem object
            player.gems += 1;
            audioSource.PlayOneShot(gemCollect);
            Destroy(gameObject);
        }
    }
}