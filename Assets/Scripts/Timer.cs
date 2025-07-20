using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{

    [SerializeField] private float timeRemaining = 60.0f;

    [SerializeField] private float lowTime = 10.0f;

    public Time time;

    public bool outofTime = false;

    public TextMeshProUGUI timerText;

    void Update()
    {

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
        if (timeRemaining <= lowTime)
        {
            timerText.color = Color.red;
        }
    }
   
   private void timeGone()
    {
        if (timeRemaining <= 0)
        {
            outofTime = true;
        }
    }

    
}