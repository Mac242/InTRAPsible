using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class LightFlickering : MonoBehaviour
{
    public GameObject lightFlicker;

    [SerializeField] public float flickering;
    [SerializeField] float interval;
    [SerializeField] private float delay;
    [SerializeField] private float flickeringTime;
    public ParticleSystem particleFlickering;

    [FormerlySerializedAs("_light2D")] public GameObject light2D;
    public float lowerLight = 0.2f;
    public float normalizeLight = 0.8f;
    private Light2D _light2D;


    // Start is called before the first frame update
    void Start()
    {
        _light2D = light2D.GetComponent<Light2D>();
       
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

        if (flickering <= 1f)
        {
            _light2D.intensity = lowerLight;
            
                 if (flickering <= .5f)
                 {
                      particleFlickering.Emit(1);
            
                 }
        }
        else
        {
            _light2D.intensity = normalizeLight;
            particleFlickering.Stop();
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
