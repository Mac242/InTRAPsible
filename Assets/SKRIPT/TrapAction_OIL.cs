using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAction_OIL : MonoBehaviour
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
    
    // Start is called before the first frame update
    void Start()
    {   
        Player_CTRL = Player.GetComponent<Player_CTRL>(); 
        Hit.SetActive(false);
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
        {  
            Player_CTRL.PlayerIsTrapped = true;
            Player_CTRL.TrappedOil = true;
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
            Player_CTRL.TrappedOil = true;
            // Move Character to Reset Position defined
            //TrapParticleSystem.Play();
            Hit.SetActive(true);

            //if (Player.transform.position == MarkerReset.transform.position)
            //{
                trapDefenseLaunchedb = false;
                trapDefenseFinishedb = true;
            //}
            Player_CTRL.isOnGround = true;
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
            Player_CTRL.TrappedOil = false;
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
        Player.transform.position = Vector2.MoveTowards(Player.transform.position, MarkerReset.transform.position, 10.0f * Time.deltaTime);
        }
    }
}