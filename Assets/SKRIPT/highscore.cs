using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class highscore : MonoBehaviour
{
    public List<TMP_Text> leaderboardNames = new List<TMP_Text>(new TMP_Text[1]);
    public List<TMP_Text> leaderboardTime = new List<TMP_Text>(new TMP_Text[1]);
    public TMP_Text submittedName;
    public TMP_Text overallTimeText;
    public float timeToBoard;
    public float timeNotToBoard;
    public float rank1;

    public GameObject losePanel;

    private void Start()
    {
        rank1 = 77f;
        losePanel.SetActive(false);
        leaderboardNames[0].text = "Anna the Dev";
        leaderboardTime[0].text = "" + rank1 + "seconds";
        
    }
    
    void Update()
    {
        timeToBoard = Player_CTRL.overallTime;
        
        if (Player_CTRL.overallTime < rank1)
        {
            leaderboardNames[0].text = submittedName.text;
            timeToBoard = (float) Math.Round(Player_CTRL.overallTime,2);
            leaderboardTime[0].text = "" + timeToBoard + "seconds";
            losePanel.SetActive(false);
        }

        if (Player_CTRL.overallTime >= rank1)
        {
            losePanel.SetActive(true);
            timeNotToBoard = (float) Math.Round(Player_CTRL.overallTime,2);
            overallTimeText.text = "Your Overall Time:" + timeNotToBoard;
        }
    }

    public void SetNull()
    {
        Player_CTRL.overallTime = 0;
    }

   
}
