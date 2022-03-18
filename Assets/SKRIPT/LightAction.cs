using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class LightAction : MonoBehaviour
{
    public GameObject player;
    public GameObject markerReset;

    //public ParticleSystem TrapParticleSystem;
    private Player_CTRL Player_Ctrl;
    public GameObject Hit;
    
    //booleans
    private bool trapActivatedb = false;
    private bool trapDefenseLaunchedb = false;
    private bool trapDefenseFinishedb = false;
    
    //Variables for function
    private float trapActivatedTimer = -0.5f;
    private float trapDefenseLaunchedTimer = -0.5f;
    private float trapDefenseFinishedTimer = 1.0f;
    
    public bool inTheLight;
    public bool exitTrigger;
    public int triggersIn;

    // Start is called before the first frame update
    void Start()
    {
        Player_Ctrl = player.GetComponent<Player_CTRL>();
        Hit.SetActive(false);
        //triggersIn = 0;
    }
  
    void Update()
    {
        if (trapActivatedb) trapActivated();
        if (trapDefenseLaunchedb) trapDefenseLaunched();
        if (trapDefenseFinishedb) trapDefenseFinished();
        
        if (triggersIn==0)
        {
            trapActivatedb = true;
            Debug.Log("DARK");
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
            Player_Ctrl.TrappedLight = true;
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
