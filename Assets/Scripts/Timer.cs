using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{

    [SerializeField] public float timeRemaining = 60.0f;

    [SerializeField] public float lowTime = 10.0f; 


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
   
            SceneManager.LoadScene("timeLoss");
        }
    }

    
}