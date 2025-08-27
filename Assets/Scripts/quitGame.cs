using UnityEngine;

public class quitGame : MonoBehaviour
{
    public pauseMenu pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void quitApplication()
    {

        Application.Quit();
        //This is here so if the game is paused and quit it will unpause  
        Time.timeScale = 1f;
        pauseMenu.GameIsPaused = false;
    }
}
