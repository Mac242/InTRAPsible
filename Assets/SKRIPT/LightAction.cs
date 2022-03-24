using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightAction : MonoBehaviour
{
    public GameObject player;
    public GameObject markerReset;
    public GameObject flashlight;
    public GameObject darkness;
    public GameObject Hit;
    private Player_CTRL Player_Ctrl;
    
    //booleans
    private bool trapActivatedb = false;
    private bool trapDefenseLaunchedb = false;
    private bool trapDefenseFinishedb = false;
    public bool flashlightOn = false;
    public bool inTheLight;
    public bool exitTrigger;
    
    //Variables for function
    private float trapActivatedTimer = -0.5f;
    private float trapDefenseLaunchedTimer = -0.5f;
    private float trapDefenseFinishedTimer = 1.0f;
    
    public int triggersIn;

    //public static int flashlightsNumber;
    public static float batteriesLoad;
    public TextMeshProUGUI flashlightsNumberText;
    public TextMeshProUGUI batteriesLoadedText;
    
    // Start is called before the first frame update
    void Start()
    {
        Player_Ctrl = player.GetComponent<Player_CTRL>();
        Hit.SetActive(false);
        //triggersIn = 0;
        flashlight.SetActive(false);
        darkness.SetActive(true);
        flashlightOn = false;
    }

    void Update()
    {
        //flashlightsNumberText.text = "Lights:" + " " + flashlightsNumber;
        batteriesLoadedText.text = "Batterie" + " " + batteriesLoad;
        
        if (trapActivatedb==true) trapActivated();
        if (trapDefenseLaunchedb) trapDefenseLaunched();
        if (trapDefenseFinishedb) trapDefenseFinished();
        
        if (triggersIn==0)
        {
            trapActivatedb = true;
            Debug.Log("DARK");
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
            }

            
            
            if (Input.GetKeyUp(KeyCode.E) && flashlightOn==true)
            {
                flashlight.SetActive(false);
                flashlightOn = false;
                darkness.SetActive(true);
                triggersIn -= 1;
                Debug.Log("unpressed E");
            }
        }
        
        if (flashlightOn==true && batteriesLoad > 0)
        {
            batteriesLoad -= Time.deltaTime;
        }
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
            // Move Character to Reset Position defined
            // TrapParticleSystem.Play();
            Hit.SetActive(true);
            //if (Player.transform.position == MarkerReset.transform.position)
            //{
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
        if (trapDefenseFinishedTimer < 0.0f)
        {
            // After arrive on Reset Position
            // Stop Particle Effect
            // Resume Idle Animation Character
            // Unblock Input
            Player_Ctrl.PlayerIsTrapped = false;
            //Player_CTRL.TrappedLight = false;
            trapDefenseFinishedb = false;
            //TrapParticleSystem.Stop();
            Hit.SetActive(false);
            trapActivatedTimer = -0.5f;
            trapDefenseLaunchedTimer = -0.5f;
            trapDefenseFinishedTimer = 2.0f;
        }
        else
        {
            //Charakter will be pushed back until he reaches MarkerReset
            //will be pushed back for X seconds
            trapDefenseFinishedTimer -= Time.deltaTime;
            player.transform.position = Vector2.MoveTowards(player.transform.position, markerReset.transform.position,
                10.0f * Time.deltaTime);
        }
    }
}
