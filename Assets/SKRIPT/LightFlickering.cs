using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickering : MonoBehaviour
{
    public GameObject lightFlicker;

    [SerializeField] float flickering;
    [SerializeField] float interval;
    [SerializeField] private float delay;
    [SerializeField] private float flickeringTime;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Flickering();
        delay -= Time.deltaTime;
        
        if (flickering <= 0)
        {
            lightFlicker.SetActive(false);
            FlickeringInterval();

            if (flickering <= 0 && interval <= 0)
            {
                flickering = flickeringTime;
                interval = 0.25f;
                lightFlicker.SetActive(true);
            }
        }
    }

    void Flickering()
    {
        if (delay <= 0)
        {
            flickering -= Time.deltaTime;
        }
    }

    void FlickeringInterval()
    {
        interval -= Time.deltaTime;
    }
}
