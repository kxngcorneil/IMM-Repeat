using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    [SerializeField] public string sceneName; // Set the name of the scene you want to change to in the inspector
    public pauseMenu pauseMenu;

    void Start()
    {
   
    }

    public void changeScene()
    {
        //When button is pressed it will load sceneName
         
        SceneManager.LoadScene(sceneName);
         Time.timeScale = 1f;
        pauseMenu.GameIsPaused = false;
    }
    

    
    
}