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
         GameIsPaused = false;
        Debug.Log("Resume called" + GameIsPaused);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
       
    }
    void Pause()
    {
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
               SceneManager.LoadScene("titleScreen");
    }
}