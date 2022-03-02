using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Audio : MonoBehaviour

{   public AudioClip bgSound;
    public AudioClip jumpSound;
    public AudioClip Atmo;
    
    public AudioSource _audioSource1;
    public AudioSource _audioSource3;
   

    // Start is called before the first frame update
    void Start()
    {
        _audioSource1.Play();
        _audioSource3.Play();
        
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
