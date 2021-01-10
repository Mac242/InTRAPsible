using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text timeText;

    private void Start()
    {
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
}
