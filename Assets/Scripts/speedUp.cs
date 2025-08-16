using UnityEngine;

public class speedUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Timer timer;
    [SerializeField] private AudioSource musicSource;

    // Update is called once per frame
    void Update()
    {
       

        if (timer.timeRemaining <= timer.lowTime)
        {
            musicSource.pitch = 1.8f; // Speed up the music when the timer is running low
        }
        else
        {
            musicSource.pitch = 1.0f; // Reset the pitch to normal when not running low
        }
    }
}
