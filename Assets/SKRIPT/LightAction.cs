using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class LightAction : MonoBehaviour
{
    public GameObject player;
    public GameObject[] markerReset;
    public GameObject flashlight;
    public GameObject darkness;
    public GameObject hit;
    private Player_CTRL Player_Ctrl;
    public GameObject globalLight;
    public Slider brightnessSlider;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioSource _audioSourceClick;
    
    
    //booleans
    private bool trapActivatedb = false;
    private bool trapDefenseLaunchedb = false;
    private bool trapDefenseFinishedb = false;
    public bool flashlightOn = false;
    public bool inTheLight;
    public bool exitTrigger;
    private float activateTraps;
    public bool activatedTraps;
    
    
    //Variables for function
    [SerializeField] private float trapActivatedTimer = -0.5f;
    [SerializeField] private float trapDefenseLaunchedTimer = -0.5f;
    [SerializeField] private float trapDefenseFinishedTimer = 1.0f;
    [SerializeField] private float yPointForMarker1;
    [SerializeField] private float yPointForMarker2;
    
    [SerializeField] private float xPointForMarker1;
    [SerializeField] private float xPointForMarker2;
    
    
    public int triggersIn;

    //public static int flashlightsNumber;
    public static float batteriesLoad;

    private float batteriesLoadRounded;
    //public TextMeshProUGUI flashlightsNumberText;
    public TextMeshProUGUI batteriesLoadedText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(inTheLight);
        Player_Ctrl = player.GetComponent<Player_CTRL>();
        hit.SetActive(false);
        //triggersIn = 0;
        flashlight.SetActive(false);
        darkness.SetActive(true);
        flashlightOn = false;
        inTheLight = true;
        Player_Ctrl.PlayerIsTrapped = false;
        activateTraps = 0.5f;
        activatedTraps = false;
    }

    void Update()
    {
        if (activateTraps > 0)
        {
            activateTraps -= Time.deltaTime;
        }
        
        if (activateTraps <= 0)
        {
            activatedTraps = true;
            Debug.Log(activatedTraps);
            Debug.Log(activateTraps);
        }

            batteriesLoadRounded = (float) Math.Round(batteriesLoad,1);
        //flashlightsNumberText.text = "Lights:" + " " + flashlightsNumber;
        batteriesLoadedText.text = "Batterie" + " " + batteriesLoadRounded;
        
        if (trapActivatedb==true) trapActivated();
        if (trapDefenseLaunchedb) trapDefenseLaunched();
        if (trapDefenseFinishedb) trapDefenseFinished();
        
        
        if (triggersIn==0 && activatedTraps==true)
        {
            trapActivatedb = true;
            Debug.Log("DARK");
            
            //_audioSource.Play();
        }

        if (batteriesLoad <= 0 && flashlightOn==true)
            //if (flashlightsNumber == 0)
        {
            flashlightOn = false;
            flashlight.SetActive(false);
            darkness.SetActive(true);
            batteriesLoad = 0;
            triggersIn -= 1;
        }
        
        if (batteriesLoad > 0) 
            //if (flashlightsNumber > 0)
        {
            if (Input.GetKeyDown(KeyCode.E) && flashlightOn==false)
            {
                flashlight.SetActive(true);
                flashlightOn = true;
                
                darkness.SetActive(false);
                triggersIn += 1;
                Debug.Log("E pressed");
                _audioSourceClick.Play();
            }

            
            
            if (Input.GetKeyUp(KeyCode.E) && flashlightOn==true)
            {
                flashlight.SetActive(false);
                flashlightOn = false;
                
                darkness.SetActive(true);
                triggersIn -= 1;
                Debug.Log("unpressed E");
                _audioSourceClick.Play();
            }
        }
        
        if (flashlightOn==true && batteriesLoad > 0)
        {
            batteriesLoad -= Time.deltaTime;
        }
    }

    public void Brightness()
    {
        globalLight.GetComponent<Light2D>().intensity = brightnessSlider.value;
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            exitTrigger = true;
            triggersIn -= 1;
            Debug.Log("Exit");
        }
        else
        {
            exitTrigger = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            inTheLight = true;
            triggersIn += 1;
            Debug.Log("Lighted"); 
        }
        else
        {
            inTheLight = false;
            
        }
    }
    
    public void trapActivated()
    {
        //Debug.Log("ta:"+trapActivatedTimer);
        if (trapActivatedTimer > 0.0f)
        {
            trapActivatedTimer -= Time.deltaTime;
        }
        else
        {
            Player_Ctrl.PlayerIsTrapped = true;
            trapActivatedb = false;
            trapDefenseLaunchedb = true;
            inTheLight = false;
        }
    }

    private void trapDefenseLaunched()
    {
        //Debug.Log("tdl:"+trapDefenseLaunchedTimer);
        if (trapDefenseLaunchedTimer < 0.0f)
        {
            //Debug.Log("Trap Defense Launched");
            // Start Particle Effect
            // Start Animation of Character MoveBack (maybe wait until animation is finished)
            Player_Ctrl.TrappedDarkness = true;
            // Move Character to Reset Position defined
            // TrapParticleSystem.Play();
            hit.SetActive(true);
            //if (Player.transform.position == MarkerReset.transform.position)
            //{
            
            _audioSource.Play();
            Debug.Log("PLAY");
            
            trapDefenseLaunchedb = false;
            trapDefenseFinishedb = true;
            //}
        }
        else
        {
            trapDefenseLaunchedTimer -= Time.deltaTime;
            

        }
    }

    private void trapDefenseFinished()
    {
        //Debug.Log("tdf:"+trapDefenseFinishedTimer);
        if (trapDefenseFinishedTimer < 0.0f )
        {
            // After arrive on Reset Position
            // Stop Particle Effect
            // Resume Idle Animation Character
            // Unblock Input
            Player_Ctrl.PlayerIsTrapped = false;
            Player_Ctrl.TrappedDarkness = false;
            Player_Ctrl.isOnGround = true;
            //_audioSource.Stop();
            trapDefenseFinishedb = false;
            //TrapParticleSystem.Stop();
            
            _audioSource.Stop();
            Debug.Log("STOP");
            
            hit.SetActive(false);
            trapActivatedTimer = -1f;
            trapDefenseLaunchedTimer = -0.5f;
            trapDefenseFinishedTimer = 1.0f;
            inTheLight = true;
        }
        else
        {
            //Charakter will be pushed back until he reaches MarkerReset
            //will be pushed back for X seconds
            trapDefenseFinishedTimer -= Time.deltaTime;
            
            if (player.transform.position.y > yPointForMarker2)
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, markerReset[2].transform.position,
                    6.5f * Time.deltaTime);
            }
            
            if (player.transform.position.y > yPointForMarker1 && player.transform.position.y < yPointForMarker2 )
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, markerReset[1].transform.position,
                    6.5f * Time.deltaTime);
            }

            else
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, markerReset[0].transform.position,
                    6.5f * Time.deltaTime);
            }

            if (player.transform.position.x > xPointForMarker1 && player.transform.position.x < xPointForMarker2) 
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, markerReset[1].transform.position,
                    6.5f * Time.deltaTime);
            }
           /* if (player.transform.position.x > xPointForMarker2)
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, markerReset[2].transform.position,
                    6.5f * Time.deltaTime);
            }*/
            
            if (player.transform.position.x < xPointForMarker2 && player.transform.position.y > yPointForMarker2)
            {
                player.transform.position = Vector2.MoveTowards(player.transform.position, markerReset[3].transform.position,
                    6.5f * Time.deltaTime);
            }
        }
    }
}
