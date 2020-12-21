using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public Animator animator;
    public GameObject Canvas;
    
    void Start ()
    {
        Canvas.SetActive(false);
    }

    void Update ()
    {  
      if (Input.GetKeyDown(KeyCode.Return))
              {
                  Canvas.SetActive(false);
              }
    }

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            Canvas.SetActive(true);
            //animator.SetBool("Steam",true);
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
           
        }
    }
    void OnTriggerExit2D(Collider2D collision)

        {
              animator.SetBool("Steam", false);

        }
    
}
