﻿using System.Collections;
using System.Collections.Generic;
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
    public bool PlayerIsTrapped = true;
    public GameObject WINPanel;
    public bool Trap_Light = false;
    
    

    // Start is called before the first frame update
    void Start()
    {   //animator = gameObject.GetComponent<Animator>();
        _RB = GetComponent<Rigidbody2D>();
        Physics.gravity = Physics.gravity * gravityModifier;
        animator.SetBool("Trapped", false);
        WINPanel.SetActive(false);
        Cursor.visible = false;
        Trap_Light = false;
    }
    

    void Update()
    {       
        if (!PlayerIsTrapped)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
            animator.SetBool("Trapped", false);
            animator.SetBool("Trapped_Light", false);
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
            Trap_Light = false;
            //animator.ResetTrigger("TrapLightning");
            //animator.ResetTrigger("TrapSteam");
            

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                _RB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isOnGround = false;
                animator.SetBool("Jump", true);
            }

            if (isOnGround)
            {
                animator.SetBool("Jump", false);
            }
        
            if (Input.GetKeyDown(KeyCode.DownArrow))
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
        }

        if(Crouch)
            {
                transform.Translate(Vector2.right * Time.deltaTime * Crouchspeed * horizontalInput);
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

          if (PlayerIsTrapped)
            {
            animator.SetBool("Trapped", true);
            Crouch = false;
			m_CrouchDisableCollider.enabled = true;
            animator.SetBool("crouch", false);
            }


         if(Trap_Light==true)
        {
            animator.SetBool("Trapped_Light", true);
        }        
    }

    

    void OnTriggerEnter2D(Collider2D other)
    {   
       if(other.CompareTag("TrapLightning"))
        {
            Trap_Light = true;
        }

        if(other.CompareTag ("Finish"))
            {
             WIN();
            }
    }

    void WIN()
    {
        Cursor.visible = true;
        //Make player disappear and be disabled
        gameObject.SetActive(false);
        

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
    
}