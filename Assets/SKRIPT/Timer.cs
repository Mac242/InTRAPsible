using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{   
    public float time;
    public Text timeText;
    private Player_CTRL Player_CTRL;
  

    private void Start()
    {   
        Player_CTRL = GetComponent<Player_CTRL>(); 
        time = 0f; 
    }

    void Update()
    {
        time += Time.deltaTime;
        DisplayTime(time);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }

     void Stop()
        {
            time += Time.deltaTime;
            Player_CTRL.WIN();
        }
}
