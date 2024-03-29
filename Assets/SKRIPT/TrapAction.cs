﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAction : MonoBehaviour
{
    public GameObject Player;
    public GameObject MarkerReset;
    //public ParticleSystem TrapParticleSystem;
    private Player_CTRL Player_CTRL;
    public GameObject Hit;
    
    // Start is called before the first frame update
    void Start()
    {
        Player_CTRL = Player.GetComponent<Player_CTRL>(); 
        Hit.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        //Debug.Log(gameObject.name + " just hit " + hit.name);
        StartCoroutine(Trapped());
    }

    private IEnumerator Trapped()
    {
        bool trapActivated = true;
        bool trapDefenseLaunched = false;
        bool trapDefenseFinished = false;
        
        while (trapActivated)
        {
           // Debug.Log("Trap Activated" + Time.time);
            // Block Input
            // Play Trap Sound
            // Start Animation Trap
            
            Player_CTRL.PlayerIsTrapped = true;
            trapActivated = false;
            trapDefenseLaunched = true;
            
            yield return null;
        }

        while (trapDefenseLaunched)
        {
            //Debug.Log("Trap Defense Launched");
            // Start Particle Effect
            // Start Animation of Character MoveBack (maybe wait until animation is finished)
            // Move Character to Reset Position defined
            //TrapParticleSystem.Play();
            Hit.SetActive(true);
            
            Player.transform.position = Vector2.MoveTowards(Player.transform.position, MarkerReset.transform.position, 10.0f * Time.deltaTime);

            if (Player.transform.position == MarkerReset.transform.position)
            {
                trapDefenseLaunched = false;
                trapDefenseFinished = true;
            }

            yield return null;
        }

        while (trapDefenseFinished)
        {
            // After arrive on Reset Position
            // Stop Particle Effect
            // Resume Idle Animation Character
            // Unblock Input
            Player_CTRL.PlayerIsTrapped = false;
            trapDefenseFinished = false;
            //TrapParticleSystem.Stop();
            Hit.SetActive(false);
            
            yield return null;
        }
        
        yield return null;
        //Debug.Log("Coroutine Done: Player Released");
    }

}


