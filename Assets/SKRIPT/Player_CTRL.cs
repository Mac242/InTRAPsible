﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_CTRL : MonoBehaviour
{   
    public float speed = 2f; 
    public float Crouchspeed = -1f; 
    private float horizontalInput; 
    private float verticalInput; 
    private Rigidbody2D _RB;
    public float jumpForce = 10f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool Crouch = false;
    [SerializeField] private Collider2D m_CrouchDisableCollider;
    public Animator animator;
    private bool facingRight = true;
    public bool PlayerIsTrapped ;
    public bool TrappedLight ;
    public bool TrappedFist ;
    public bool TrappedOil ;
    public bool TrappedDarkness ;
    public AudioClip walkSound;
    public AudioClip crouchSound;
    public AudioSource _audioSource;
    //Time
    public float time;
    public Text timeText;
    private float minutes;
    private float seconds;
    public GameObject WINPanel;
    public GameObject pausePanel;
    public bool paused;
    public GameObject winPanelGold;
    public GameObject winPanelSilver;
    public GameObject winPanelBronze;
    public TextMeshProUGUI winTime;

    private LightAction _lightAction;
    

    // Start is called before the first frame update
    void Start()
    {   
        _RB = GetComponent<Rigidbody2D>();
        Physics.gravity = Physics.gravity * gravityModifier;
        animator.SetBool("Trapped", false);
        WINPanel.SetActive(false);
        winPanelGold.SetActive(false);
        winPanelSilver.SetActive(false);
        winPanelBronze.SetActive(false);
        Cursor.visible = false;
        TrappedLight = false;
        TrappedFist = false;
        TrappedOil = false;
        TrappedDarkness = false;
        PlayerIsTrapped = false;
        _lightAction = GetComponent<LightAction>();
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        paused = false;

    }
    

    void Update()
    {       
        DisplayTime();
        Pause();

        if (!PlayerIsTrapped)
        {   
            horizontalInput = Input.GetAxisRaw("Horizontal");
            transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
            animator.SetBool("Trapped", false);
            animator.SetBool("Trapped_Darkness", false);
            animator.SetBool("Trapped_Light", false);
            animator.SetBool("Trapped_Fist", false);
            animator.SetBool("Trapped_Oil", false);
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
            animator.SetBool("FL_ON", false);
            TrappedLight = false;
            TrappedFist = false;
            TrappedOil = false;
            TrappedDarkness = false;

            if (Input.GetKey(KeyCode.Space) && isOnGround)
            {
                _RB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isOnGround = false;
                animator.SetBool("Jump", true);
            }

            if (isOnGround)
            {
                animator.SetBool("Jump", false);
            }
        
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Crouch = true;
			    m_CrouchDisableCollider.enabled = false;
                animator.SetBool("crouch", true);
            } 
        
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Crouch = false;
                m_CrouchDisableCollider.enabled = true;
                animator.SetBool("crouch", false);
            }

            if (_lightAction.flashlightOn == true)
            {
                animator.SetBool("FL_ON", true);
            }
            else
            {
                animator.SetBool("FL_ON", false);
            }
        }

        if(Crouch)
        {
            transform.Translate(Vector2.right * Time.deltaTime * Crouchspeed * horizontalInput);
            _audioSource.Stop();
        }
        
        if(PlayerIsTrapped)
        {
            animator.SetBool("Trapped", true);
            Crouch = false;
            m_CrouchDisableCollider.enabled = true;
            animator.SetBool("crouch", false);
        }

        if (PlayerIsTrapped && TrappedDarkness==true)
        {
            animator.SetBool("Trapped_Darkness", true);
        }
            
        if (PlayerIsTrapped && TrappedLight==true)
        {
            animator.SetBool("Trapped_Light", true);
        }
        
        if (PlayerIsTrapped && TrappedFist==true)
        {
            animator.SetBool("Trapped_Fist", true);   
        }

        if (PlayerIsTrapped && TrappedOil==true)
        {
            animator.SetBool("Trapped_Oil", true);   
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _audioSource.Stop();
        }
    }
    void FixedUpdate()
    {
        if (facingRight == false && horizontalInput > 0)
        {
			Flip();
        }
        else if (facingRight == true && horizontalInput < 0)
        {
			Flip();
        }
    }
    void Flip()
    {
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
    }
    private void OnCollisionEnter2D(Collision2D collision)

    {   isOnGround = true;
        
        if(this.CompareTag("TrapLight"))
        {
            TrappedLight = true;
        }

        if(this.CompareTag("TrapFist"))
        {
            TrappedFist = true;
        }

        if(this.CompareTag("TrapOil"))
        {
            TrappedOil = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.CompareTag ("Finish"))
        {
            WIN();
        }
    }
    void DisplayTime()
    {
        time += Time.deltaTime;
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    public void WIN()
    {
        Cursor.visible = true;
        //Make player disappear and be disabled
        Time.timeScale = 0;

        if (time < 36f)
        {
            winPanelGold.SetActive(true);
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            winTime.text = "You run this basement in " + string.Format("{0:00}:{1:00}", minutes , seconds);
            //LightAction.flashlightsNumber += 3;
            LightAction.batteriesLoad += 5f;
        }
        else if (time < 60f && time >= 36f)
        {
            winPanelSilver.SetActive(true);
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            winTime.text = "You walked this basement in " + string.Format("{0:00}:{1:00}", minutes , seconds);
            LightAction.batteriesLoad += 3f;
        }
        else if (time >= 60f)
        {
            winPanelBronze.SetActive(true);
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);
            winTime.text = "You escaped this basement in " + string.Format("{0:00}:{1:00}", minutes , seconds);
            LightAction.batteriesLoad += 1f;
        }
        
        //turn on WINPAnel
        WINPanel.SetActive(true);
    }

        //playAgainButton from the WINPanel
    public void PlayAgain()
    {
        Cursor.visible = true;
        //restart the game
        SceneManager.LoadScene("SampleScene");
    }

        //quitButton from the GameOverPanel
    public void Quit()
    {
        //close the window where the game is being played in 
        Application.Quit();
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            pausePanel.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
            paused = true;
            Debug.Log("Pause");
        }
        
        else if (paused == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Unpause();
        }

    }

    public void Unpause()
    {
        pausePanel.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        paused = false;
        Debug.Log("unpause");
    }

   
    
}