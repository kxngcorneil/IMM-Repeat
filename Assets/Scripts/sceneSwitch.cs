using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{
    [SerializeField] public string sceneName; // Now you can assign in Inspector

    void Start()
    {
   
    }

    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    

    
    
}