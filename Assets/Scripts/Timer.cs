using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField] private float timeSet = 50f; // Initial time in seconds
    private float currentTime;
    public TextMeshProUGUI countdown;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
    }

    void Update()
    {
        currentTime -= Time.deltaTime; // Decrease current time by the time passed since last frame
    }




}
   
