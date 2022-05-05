using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int buildIndex;
    private Player_CTRL _playerCtrl;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.visible = true;
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        _playerCtrl= GetComponent<Player_CTRL>();
    }

    // Update is called once per frame

    public void NextLevel()
    {
        SceneManager.LoadScene(buildIndex + 1);
    }
    
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SetNull()
    {
        Player_CTRL.overallTime = 0;
        
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(buildIndex);
    }
}
