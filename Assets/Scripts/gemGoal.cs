using UnityEngine;

public class gemGoal : MonoBehaviour
{

    [SerializeField] public float gemRequirement = 5;
    
      public PlayerMovement player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gems >= gemRequirement)
        {
            // If the player has collected enough gems, destroy the game object
            Destroy(gameObject);
        }
    }
}
