using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;


public class Timer: MonoBehaviour {

    [SerializeField] private float timeRemaining = 60.0f;

    [SerializeField] private float lowTime = 10.0f;

    public Time time;

    public TextMeshProUGUI timerText;

    void Update()
    {

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0.0f)
        {
            timerEnded();
        }


        timerText.text = timeRemaining.ToString("F0"); //  0 decimal places

    }

    void timerEnded()
    {


    }
}