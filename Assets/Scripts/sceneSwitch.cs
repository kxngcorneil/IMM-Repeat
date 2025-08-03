using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    [SerializeField] public string sceneName; // Set the name of the scene you want to change to in the inspector

    void Start()
    {
   
    }

    public void changeScene()
    {
        //When button is pressed it will load sceneName 
        SceneManager.LoadScene(sceneName);
    }
    

    
    
}