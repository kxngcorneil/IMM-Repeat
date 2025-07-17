using System;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 2f; //Platform speed

    [SerializeField] private float timerForeward = 0f;// Time to move forward
    [SerializeField] private float timerBackward = 0f; // Time to move backward

    [SerializeField] private float restartTime = 2f; // Time to wait before restarting the movement

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }

    private void movePlatform()
    {

        // If timer bigger than 0 platform moves
        if (timerForeward > 0)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            timerForeward -= Time.deltaTime;
            flipFirst();
        }

        // Once timerForeward is 0, platform starts moving backward
        else if (timerBackward > 0)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            timerBackward -= Time.deltaTime;
           // flipSecond();
        }
        //Once both timers are 0 or less reset timers
        else if (timerForeward <= 0 && timerBackward <= 0)
        {

            timerForeward = restartTime;
            timerBackward = restartTime;

        }
    }

    private void flipFirst()
    {
        transform.Rotate(0, 180, 0);
    }

    private void flipSecond()
    {
        transform.Rotate(0, -180, 0);

    }
}
