using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    void Update()
    {
       
        //if escape key is pressed pause varaible switches depending on if the game was paused already of not
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed! GameIsPaused = " + GameIsPaused);
            
            if (GameIsPaused == true)
            {
                Resume();
            }
            else if (!GameIsPaused)     
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //if game was already pause we resume the game which unpauses the game and everything resu,es
         GameIsPaused = false;
        Debug.Log("Resume called" + GameIsPaused);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
       
    }
    void Pause()
    {
        //if the game wasnt paused previously we freeze the game and make it so the pause UI appears
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
    }

    public void LoadOptions()
    {
        Time.timeScale = 0f;
        SceneManager.LoadScene("options");
    }

    public void titleScreen()
    {
        //if exit button is pressed take player back to the title screen
        SceneManager.LoadScene("titleScreen");
    }
}