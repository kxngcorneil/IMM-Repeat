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
        gemDifference = requiredGems.gemRequirement - player.gems;
        
        if (player.gems < requiredGems.gemRequirement)
        {
            objectiveTextUI.text = "Collect " + gemDifference + " more gems";
        }
        else
        {
            objectiveTextUI.text = "All gems collected! Head to the goal!";
        }
        
    }
}
