﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAction_V2 : MonoBehaviour
{
    public GameObject Player;
    public GameObject MarkerReset;
    
    //public ParticleSystem TrapParticleSystem;
    private Player_CTRL Player_CTRL;
    public GameObject Hit;
    
    //booleans
    bool trapActivatedb = false;
    bool trapDefenseLaunchedb = false;
    bool trapDefenseFinishedb = false;

    //Variables for function
    float trapActivatedTimer = -0.5f;
    float trapDefenseLaunchedTimer = -0.5f;
    float trapDefenseFinishedTimer = 1.0f;

    private LightAction _lightAction;

    [SerializeField] private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {   
        Player_CTRL = Player.GetComponent<Player_CTRL>(); 
        Hit.SetActive(false);
        _lightAction = Player.GetComponent<LightAction>();
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        //Debug.Log(gameObject.name + " just hit " + hit.name);
        //StartCoroutine(Trapped());
        trapActivatedb = true;
    }

    void Update(){
        if(trapActivatedb)trapActivated();
        if(trapDefenseLaunchedb)trapDefenseLaunched();
        if(trapDefenseFinishedb)trapDefenseFinished();
    }

    void trapActivated(){
        //Debug.Log("ta:"+trapActivatedTimer);
        if(trapActivatedTimer > 0.0f){
            trapActivatedTimer -= Time.deltaTime;
        }
        else
        {  // Player_CTRL.TrappedLight = true;
            Player_CTRL.PlayerIsTrapped = true;
            trapActivatedb = false;
            trapDefenseLaunchedb = true;
        }
    }

void trapDefenseLaunched()
    {
    //Debug.Log("tdl:"+trapDefenseLaunchedTimer);
        if(trapDefenseLaunchedTimer < 0.0f)
        {
            //Debug.Log("Trap Defense Launched");
            // Start Particle Effect
            // Start Animation of Character MoveBack (maybe wait until animation is finished)

            // Move Character to Reset Position defined
           // TrapParticleSystem.Play();
            Hit.SetActive(true);
            
            
               /* if (LightAction.flashlightsNumber > 0 && _lightAction.flashlightOn==true)
            {
                LightAction.flashlightsNumber -= 1;
            }

            if (LightAction.flashlightsNumber == 0 && _lightAction.flashlightOn == true)
            {
                _lightAction.triggersIn -= 1;
                _lightAction.flashlightOn = false;
            }*/
               
               _audioSource.Play();
               
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

void trapDefenseFinished()
    {
    //Debug.Log("tdf:"+trapDefenseFinishedTimer);
        if(trapDefenseFinishedTimer < 0.0f)
        {
            // After arrive on Reset Position
            // Stop Particle Effect
            // Resume Idle Animation Character
            // Unblock Input
            Player_CTRL.PlayerIsTrapped = false;
            //Player_CTRL.TrappedLight = false;
            trapDefenseFinishedb = false;
            //TrapParticleSystem.Stop();
            Hit.SetActive(false);
            trapActivatedTimer = -0.5f;
            trapDefenseLaunchedTimer = -0.5f;
            trapDefenseFinishedTimer = 2.0f;
            Player_CTRL.isOnGround = true;
            
            _audioSource.Stop();
        }
        else
        {
        //Charakter will be pushed back until he reaches MarkerReset
        //will be pushed back for X seconds
        trapDefenseFinishedTimer -= Time.deltaTime;
        Player.transform.position = Vector2.MoveTowards(Player.transform.position, MarkerReset.transform.position, 10.0f * Time.deltaTime);
        }
    }
}