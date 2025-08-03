using UnityEngine;
using TMPro;

public class objectiveText : MonoBehaviour
{
    public PlayerMovement player;
    public gemGoal requiredGems; // Reference to the gemGoal script

    private float gemDifference;
    public TextMeshProUGUI objectiveTextUI; // Reference to the UI Text component

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Set the gem difference between what the player has and what is needed to beat the level
        gemDifference = requiredGems.gemRequirement - player.gems;

        if (player.gems < requiredGems.gemRequirement)
        {
            // Use that difference to indicate to the player how many more gems are needed to beat the level
            objectiveTextUI.text = "Collect " + gemDifference + " more gems";
        }
        else
        {
            // If the player has enough gems, the text changes, telling the player to go to the goal
            objectiveTextUI.text = "All gems collected! Head to the goal!";
        }
    }
}