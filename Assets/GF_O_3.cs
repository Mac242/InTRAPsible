using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GF_O_3 : MonoBehaviour
{
   
    public GameObject Hit;

    // Start is called before the first frame update
    void Start()
    {
        Hit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
       Hit.SetActive(true);
    }
}
