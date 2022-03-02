﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    
void Start()

{
    Cursor.visible = true;
}

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}