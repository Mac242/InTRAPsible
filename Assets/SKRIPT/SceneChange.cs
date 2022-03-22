using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int buildIndex;
    
    public GameObject player;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        buildIndex = SceneManager.GetActiveScene().buildIndex;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(buildIndex + 1);
    }
}
