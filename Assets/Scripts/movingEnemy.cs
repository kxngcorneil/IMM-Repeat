using System;
using UnityEngine;

public class movingEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f; 

     private float timerForeward = 0f;
     private float timerBackward = 0f; 

    [SerializeField] private float restartTime = 2f; 

    private bool faceRight;
    private bool faceLeft;

    private bool isMovingRight = true; 
    private bool isMovingLeft = false; // Flag to check if the platform is moving left

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }

    private void movePlatform()
    {

       
        if (timerForeward > 0)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            timerForeward -= Time.deltaTime;
            if (!isMovingRight)
            {
                isMovingRight = true;
                isMovingLeft = false;
                flipSecond();
            }
        }

       
        else if (timerBackward > 0)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            timerBackward -= Time.deltaTime;
            if (!isMovingLeft)
            {
                isMovingRight = false;
                isMovingLeft = true;
                flipSecond();
            }
        }
       
        else if (timerForeward <= 0 && timerBackward <= 0)
        {
          timerForeward = restartTime;
            timerBackward = restartTime;

        }
    }

    
    private void flipSecond()
    {
        if (isMovingRight && !isMovingLeft)
        {
            transform.localScale = new Vector3(21, 21, 21);
        }
        else if (isMovingLeft && !isMovingRight)
        {
            transform.localScale = new Vector3(-21, 21, 21); 
        }
    }
}
