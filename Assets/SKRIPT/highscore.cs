using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class highscore : MonoBehaviour
{
    public List<TMP_Text> leaderboardNames = new List<TMP_Text>();
    public List<TMP_Text> leaderboardTime = new List<TMP_Text>();
    public List<string> leaderboardNamesStorage = new List<string>();
    public List<float> scoreTime = new List<float>();
    public TMP_Text submittedName;
    public TMP_Text overallTimeText;
    
    public float timeToBoard;
    
    public float rank1, rank2, rank3, rank4, rank5, rank6, rank7, rank8, rank9, rank10,
    rank11;

    private bool first, second, third, fourth, fifth, sixth, seventh, eighth, nineth, tenth;
    
    public GameObject losePanel;
   
   

    private void Start()
    {
    }

    private void Update()
    {
        overallTimeText.text = "Your Time is" + " " + (float) Math.Round(Player_CTRL.overallTime,2);
        
        if (Input.GetKey(KeyCode.Escape))
        {
         
        }
    }
    
    
    public void LoadScore()
    {
        first = false;
        second = false;
        third = false;
        fourth = false;
        fifth = false;
        sixth = false;
        seventh = false;
        eighth = false;
        nineth = false;
        tenth = false;
        
        rank1 = 73f;
        rank2 = 100f;
        rank3 = 120f;
        rank4 = 130f;
        rank5 = 140f;
        rank6 = 150f;
        rank7 = 160f;
        rank8 = 170f;
        rank9 = 180f;
        rank10 = 190f;
        rank11 = Player_CTRL.overallTime;
        
        
        scoreTime[0] = rank1;
        scoreTime[1] = rank2;
        scoreTime[2] = rank3;
        scoreTime[3] = rank4;
        scoreTime[4] = rank5;
        scoreTime[5] = rank6;
        scoreTime[6] = rank7;
        scoreTime[7] = rank8;
        scoreTime[8] = rank9;
        scoreTime[9] = rank10;
        scoreTime[10] = rank11;
        
       
        //leaderboardNames[0].text = "Anna the Dev";
        leaderboardTime[0].text = "" + (float) Math.Round(rank1,2) + " " + "seconds";
        //leaderboardNames[1].text = "Anna the Dev";
        leaderboardTime[1].text = "" + (float) Math.Round(rank2,2) + " " + "seconds";
        //leaderboardNames[2].text = "Anna the Dev";
        leaderboardTime[2].text = "" + (float) Math.Round(rank3,2) + " " + "seconds";
        //leaderboardNames[3].text = "Anna the Dev";
        leaderboardTime[3].text = "" + (float) Math.Round(rank4,2) + " " + "seconds";
        //leaderboardNames[4].text = "Anna the Dev";
        leaderboardTime[4].text = "" + (float) Math.Round(rank5,2) + " " + "seconds";
        //leaderboardNames[5].text = "Anna the Dev";
        leaderboardTime[5].text = "" + (float) Math.Round(rank6,2) + " " + "seconds";
        //leaderboardNames[6].text = "Anna the Dev";
        leaderboardTime[6].text = "" + (float) Math.Round(rank7,2) + " " + "seconds";
        //leaderboardNames[7].text = "Anna the Dev";
        leaderboardTime[7].text = "" + (float) Math.Round(rank8,2) + " " + "seconds";
        //leaderboardNames[8].text = "Anna the Dev";
        leaderboardTime[8].text = "" + (float) Math.Round(rank9,2)+ " " + "seconds";
        //leaderboardNames[9].text = "Anna the Dev";
        leaderboardTime[9].text = "" + (float) Math.Round(rank10,2) + " " + "seconds";
        
        timeToBoard = (float) Math.Round(Player_CTRL.overallTime,2);

         leaderboardNamesStorage[0] = leaderboardNames[0].text;
         leaderboardNamesStorage[1] = leaderboardNames[1].text;
         leaderboardNamesStorage[2] = leaderboardNames[2].text;
         leaderboardNamesStorage[3] = leaderboardNames[3].text;
         leaderboardNamesStorage[4] = leaderboardNames[4].text;
         leaderboardNamesStorage[5] = leaderboardNames[5].text;
         leaderboardNamesStorage[6] = leaderboardNames[6].text;
         leaderboardNamesStorage[7] = leaderboardNames[7].text;
         leaderboardNamesStorage[8] = leaderboardNames[8].text;
         leaderboardNamesStorage[9] = leaderboardNames[9].text;
         leaderboardNamesStorage[10] = leaderboardNames[10].text;

         if (timeToBoard < rank1)
         {
             first = true;
             
             leaderboardNames[0].text = leaderboardNamesStorage[10];
             leaderboardNames[1].text = leaderboardNamesStorage[0];
             leaderboardNames[2].text = leaderboardNamesStorage[1];
             leaderboardNames[3].text = leaderboardNamesStorage[2];
             leaderboardNames[4].text = leaderboardNamesStorage[3];
             leaderboardNames[5].text = leaderboardNamesStorage[4];
             leaderboardNames[6].text = leaderboardNamesStorage[5];
             leaderboardNames[7].text = leaderboardNamesStorage[6];
             leaderboardNames[8].text = leaderboardNamesStorage[7];
             leaderboardNames[9].text = leaderboardNamesStorage[8];
             leaderboardNames[10].text = leaderboardNamesStorage[9];
         }   
         
         if (timeToBoard < rank2 && timeToBoard >=rank1)
         {
             second = true;
             
             leaderboardNames[0].text = leaderboardNamesStorage[0];
             leaderboardNames[1].text = leaderboardNamesStorage[10];
             leaderboardNames[2].text = leaderboardNamesStorage[1];
             leaderboardNames[3].text = leaderboardNamesStorage[2];
             leaderboardNames[4].text = leaderboardNamesStorage[3];
             leaderboardNames[5].text = leaderboardNamesStorage[4];
             leaderboardNames[6].text = leaderboardNamesStorage[5];
             leaderboardNames[7].text = leaderboardNamesStorage[6];
             leaderboardNames[8].text = leaderboardNamesStorage[7];
             leaderboardNames[9].text = leaderboardNamesStorage[8];
             leaderboardNames[10].text = leaderboardNamesStorage[9];
         }    
         
         if (timeToBoard < rank3 && timeToBoard >=rank2)
         {
             third = true;
             
             leaderboardNames[0].text = leaderboardNamesStorage[0];
             leaderboardNames[1].text = leaderboardNamesStorage[1];
             leaderboardNames[2].text = leaderboardNamesStorage[10];
             leaderboardNames[3].text = leaderboardNamesStorage[2];
             leaderboardNames[4].text = leaderboardNamesStorage[3];
             leaderboardNames[5].text = leaderboardNamesStorage[4];
             leaderboardNames[6].text = leaderboardNamesStorage[5];
             leaderboardNames[7].text = leaderboardNamesStorage[6];
             leaderboardNames[8].text = leaderboardNamesStorage[7];
             leaderboardNames[9].text = leaderboardNamesStorage[8];
             leaderboardNames[10].text = leaderboardNamesStorage[9];
         }  
         
         if (timeToBoard < rank4 && timeToBoard >=rank3)
         {
             fourth = true;
             
             leaderboardNames[0].text = leaderboardNamesStorage[0];
             leaderboardNames[1].text = leaderboardNamesStorage[1];
             leaderboardNames[2].text = leaderboardNamesStorage[2];
             leaderboardNames[3].text = leaderboardNamesStorage[10];
             leaderboardNames[4].text = leaderboardNamesStorage[3];
             leaderboardNames[5].text = leaderboardNamesStorage[4];
             leaderboardNames[6].text = leaderboardNamesStorage[5];
             leaderboardNames[7].text = leaderboardNamesStorage[6];
             leaderboardNames[8].text = leaderboardNamesStorage[7];
             leaderboardNames[9].text = leaderboardNamesStorage[8];
             leaderboardNames[10].text = leaderboardNamesStorage[9];
         }     
         
         if (timeToBoard < rank5 && timeToBoard >=rank4)
         {
             fifth = true;
             
             leaderboardNames[0].text = leaderboardNamesStorage[0];
             leaderboardNames[1].text = leaderboardNamesStorage[1];
             leaderboardNames[2].text = leaderboardNamesStorage[2];
             leaderboardNames[3].text = leaderboardNamesStorage[3];
             leaderboardNames[4].text = leaderboardNamesStorage[10];
             leaderboardNames[5].text = leaderboardNamesStorage[4];
             leaderboardNames[6].text = leaderboardNamesStorage[5];
             leaderboardNames[7].text = leaderboardNamesStorage[6];
             leaderboardNames[8].text = leaderboardNamesStorage[7];
             leaderboardNames[9].text = leaderboardNamesStorage[8];
             leaderboardNames[10].text = leaderboardNamesStorage[9];
         }      
         
         if (timeToBoard < rank6 && timeToBoard >=rank5)
         {
             sixth = true;
             
             leaderboardNames[0].text = leaderboardNamesStorage[0];
             leaderboardNames[1].text = leaderboardNamesStorage[1];
             leaderboardNames[2].text = leaderboardNamesStorage[2];
             leaderboardNames[3].text = leaderboardNamesStorage[3];
             leaderboardNames[4].text = leaderboardNamesStorage[4];
             leaderboardNames[5].text = leaderboardNamesStorage[10];
             leaderboardNames[6].text = leaderboardNamesStorage[5];
             leaderboardNames[7].text = leaderboardNamesStorage[6];
             leaderboardNames[8].text = leaderboardNamesStorage[7];
             leaderboardNames[9].text = leaderboardNamesStorage[8];
             leaderboardNames[10].text = leaderboardNamesStorage[9];
         }     
         
         if (timeToBoard < rank7 && timeToBoard >=rank6)
         {
             seventh = true;
             
             leaderboardNames[0].text = leaderboardNamesStorage[0];
             leaderboardNames[1].text = leaderboardNamesStorage[1];
             leaderboardNames[2].text = leaderboardNamesStorage[2];
             leaderboardNames[3].text = leaderboardNamesStorage[3];
             leaderboardNames[4].text = leaderboardNamesStorage[4];
             leaderboardNames[5].text = leaderboardNamesStorage[5];
             leaderboardNames[6].text = leaderboardNamesStorage[10];
             leaderboardNames[7].text = leaderboardNamesStorage[6];
             leaderboardNames[8].text = leaderboardNamesStorage[7];
             leaderboardNames[9].text = leaderboardNamesStorage[8];
             leaderboardNames[10].text = leaderboardNamesStorage[9];
         }      
         
         if (timeToBoard < rank8 && timeToBoard >=rank7)
         {
             eighth = true;
             
             leaderboardNames[0].text = leaderboardNamesStorage[0];
             leaderboardNames[1].text = leaderboardNamesStorage[1];
             leaderboardNames[2].text = leaderboardNamesStorage[2];
             leaderboardNames[3].text = leaderboardNamesStorage[3];
             leaderboardNames[4].text = leaderboardNamesStorage[4];
             leaderboardNames[5].text = leaderboardNamesStorage[5];
             leaderboardNames[6].text = leaderboardNamesStorage[6];
             leaderboardNames[7].text = leaderboardNamesStorage[10];
             leaderboardNames[8].text = leaderboardNamesStorage[7];
             leaderboardNames[9].text = leaderboardNamesStorage[8];
             leaderboardNames[10].text = leaderboardNamesStorage[9];
         }      
         
         if (timeToBoard < rank9 && timeToBoard >=rank8)
         {
             nineth = true;
             
             leaderboardNames[0].text = leaderboardNamesStorage[0];
             leaderboardNames[1].text = leaderboardNamesStorage[1];
             leaderboardNames[2].text = leaderboardNamesStorage[2];
             leaderboardNames[3].text = leaderboardNamesStorage[3];
             leaderboardNames[4].text = leaderboardNamesStorage[4];
             leaderboardNames[5].text = leaderboardNamesStorage[5];
             leaderboardNames[6].text = leaderboardNamesStorage[6];
             leaderboardNames[7].text = leaderboardNamesStorage[7];
             leaderboardNames[8].text = leaderboardNamesStorage[10];
             leaderboardNames[9].text = leaderboardNamesStorage[8];
             leaderboardNames[10].text = leaderboardNamesStorage[9];
         }  
         
         if (timeToBoard < rank10 && timeToBoard >=rank9)
         {
             tenth = true;
             
             leaderboardNames[0].text = leaderboardNamesStorage[0];
             leaderboardNames[1].text = leaderboardNamesStorage[1];
             leaderboardNames[2].text = leaderboardNamesStorage[2];
             leaderboardNames[3].text = leaderboardNamesStorage[3];
             leaderboardNames[4].text = leaderboardNamesStorage[4];
             leaderboardNames[5].text = leaderboardNamesStorage[5];
             leaderboardNames[6].text = leaderboardNamesStorage[6];
             leaderboardNames[7].text = leaderboardNamesStorage[7];
             leaderboardNames[8].text = leaderboardNamesStorage[8];
             leaderboardNames[9].text = leaderboardNamesStorage[10];
             leaderboardNames[10].text = leaderboardNamesStorage[9];
         }      
    }
    
    public void highscoreToBoard()
    {
       leaderboardNames[10].text = submittedName.text;
       
        SetHighscore();

        if (first == true)
        {
            leaderboardNames[0].text = leaderboardNames[10].text;
            leaderboardNames[10].text = "";
        }
        
        if (second == true)
        {
            leaderboardNames[1].text = leaderboardNames[10].text;
            leaderboardNames[10].text = "";
        }
        
        if (third == true)
        {
            leaderboardNames[2].text = leaderboardNames[10].text;
            leaderboardNames[10].text = "";
        }
        
        if (fourth == true)
        {
            leaderboardNames[3].text = leaderboardNames[10].text;
            leaderboardNames[10].text = "";
        }
        
        if (fifth == true)
        {
            leaderboardNames[4].text = leaderboardNames[10].text;
            leaderboardNames[10].text = "";
        }
        
        if (sixth == true)
        {
            leaderboardNames[5].text = leaderboardNames[10].text;
            leaderboardNames[10].text = "";
        }
        
        if (seventh == true)
        {
            leaderboardNames[6].text = leaderboardNames[10].text;
            leaderboardNames[10].text = "";
        }
        
        if (eighth == true)
        {
            leaderboardNames[7].text = leaderboardNames[10].text;
            leaderboardNames[10].text = "";
        }
        
        if (nineth == true)
        {
            leaderboardNames[8].text = leaderboardNames[10].text;
            leaderboardNames[10].text = "";
        }
        
        if (tenth == true)
        {
            leaderboardNames[9].text = leaderboardNames[10].text;
            leaderboardNames[10].text = "";
        }
        /*if (Player_CTRL.overallTime < rank1)
        {
            timeToBoard = (float) Math.Round(Player_CTRL.overallTime,2);
            leaderboardTime[0].text = "" + timeToBoard + "seconds";
            rank1 = timeToBoard;
            rank1 = PlayerPrefs.GetFloat("score", timeToBoard);
        }

        else if (Player_CTRL.overallTime < rank2  && Player_CTRL.overallTime > rank1)
        {
            timeToBoard = (float) Math.Round(Player_CTRL.overallTime,2);
            leaderboardTime[1].text = "" + timeToBoard + "seconds";
            rank2 = timeToBoard;
            rank2 = PlayerPrefs.GetFloat("score", timeToBoard);
        }
        */

        /*  if (Player_CTRL.overallTime >= rank1)
          {
              losePanel.SetActive(true);
              timeNotToBoard = (float) Math.Round(Player_CTRL.overallTime,2);
              overallTimeText.text = "Your Overall Time:" + timeNotToBoard;
          } */
    }

    public void SetHighscore()
    {
        CheckScore();
        
        scoreTime.Sort(); 
        rank1 = scoreTime[0];
        rank2 = scoreTime[1];
        rank3 = scoreTime[2];
        rank4 = scoreTime[3];
        rank5 = scoreTime[4];
        rank6 = scoreTime[5];
        rank7 = scoreTime[6];
        rank8 = scoreTime[7];
        rank9 = scoreTime[8];
        rank10 = scoreTime[9];
        rank11 = scoreTime[10];
        
        leaderboardTime[0].text = "" + (float) Math.Round(rank1,2) + " " + "seconds";
        leaderboardTime[1].text = "" + (float) Math.Round(rank2,2) + " " + "seconds";
        leaderboardTime[2].text = "" + (float) Math.Round(rank3,2) + " " + "seconds";
        leaderboardTime[3].text = "" + (float) Math.Round(rank4,2) + " " + "seconds";
        leaderboardTime[4].text = "" + (float) Math.Round(rank5,2) + " " + "seconds";
        leaderboardTime[5].text = "" + (float) Math.Round(rank6,2) + " " + "seconds";
        leaderboardTime[6].text = "" + (float) Math.Round(rank7,2) + " " + "seconds";
        leaderboardTime[7].text = "" + (float) Math.Round(rank8,2) + " " + "seconds";
        leaderboardTime[8].text = "" + (float) Math.Round(rank9,2)+ " " + "seconds";
        leaderboardTime[9].text = "" + (float) Math.Round(rank10,2) + " " + "seconds";
        

    }

    public void CheckScore()
    {
        timeToBoard = Player_CTRL.overallTime;
        rank11 = timeToBoard;
    }
}
