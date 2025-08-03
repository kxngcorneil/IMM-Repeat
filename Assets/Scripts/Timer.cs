using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    //Initialize the countdown and lowTime (Able to change in inspectator)
    [SerializeField] private float timeRemaining = 60.0f; 

    [SerializeField] private float lowTime = 10.0f; 

    //set the running out of time boolean to false - changes one timer goes below lowTime variable
    public bool outofTime = false;

    //Public text object
    public TextMeshProUGUI timerText;

    void Update()
    {
        //Ticks down the time from the timeRemaining varaible 
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= lowTime)
        {
            timeLower();
        }


        timerText.text = timeRemaining.ToString("F0"); //  0 decimal places

        timeGone();

    }

    private void timeLower()
    {
        //Change text colour once the time goes below a certain number
        if (timeRemaining <= lowTime)
        {
            timerText.color = Color.red;
        }
    }
   
   private void timeGone()
    {   //if time hits 0 and player doesnt beat the stage in the time change to a game over screen
        if (timeRemaining <= 0)
        {
            outofTime = true;
            SceneManager.LoadScene("timeLoss");
        }
    }

    
}