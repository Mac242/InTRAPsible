using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;



public class Audio : MonoBehaviour

{   
    [FormerlySerializedAs("_audioSourceWalk")] public AudioSource audioSourceWalk;
    [FormerlySerializedAs("_bgSound")] public AudioSource bgSourceSound;
    public AudioSource heartbeatSourceSound;
    private Player_CTRL _playerCtrl;
    
    
   

    // Start is called before the first frame update
    void Start()
    {
        bgSourceSound.Play();
        heartbeatSourceSound.Play();
        _playerCtrl = GetComponent<Player_CTRL>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            audioSourceWalk.Play();
            Debug.Log("WalkRight");
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            audioSourceWalk.Stop();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            audioSourceWalk.Play();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            audioSourceWalk.Stop();
        }

        if (_playerCtrl.PlayerIsTrapped == true)
        {
            heartbeatSourceSound.pitch = 1.5f;
        }
        else
        {
            heartbeatSourceSound.pitch = 1.0f;
        }
    }
}
