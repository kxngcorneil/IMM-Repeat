using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
      [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip menuIn;
    [SerializeField] private AudioClip menuOut;

    public GameObject pauseMenuUI;

    void Update()
    {
        // If the Escape key is pressed, the pause variable switches depending on whether the game was already paused or not
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed! GameIsPaused = " + GameIsPaused);

            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // If the game was already paused, we resume the game, unpausing it and resuming all activity
        GameIsPaused = false;
        Debug.Log("Resume called. GameIsPaused = " + GameIsPaused);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        audioSource.PlayOneShot(menuOut);
    }

    void Pause()
    {
        // If the game wasn't paused previously, we freeze the game and display the pause UI
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        audioSource.PlayOneShot(menuIn);
    }
}