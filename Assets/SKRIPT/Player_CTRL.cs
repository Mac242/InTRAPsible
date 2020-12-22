using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CTRL : MonoBehaviour
{
    public float speed = 2f; 
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
    

    // Start is called before the first frame update
    void Start()
    {
        _RB = GetComponent<Rigidbody2D>();
        Physics.gravity = Physics.gravity * gravityModifier;
        animator.SetBool("Trapped", false);
    }
    

    void Update()
    {       
        if (!PlayerIsTrapped)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
            animator.SetBool("Trapped", false);
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                _RB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isOnGround = false;
            }
        
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Crouch = true;
			    m_CrouchDisableCollider.enabled = false;
                animator.SetBool("crouch", true);
            } 
        
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
            Crouch = false;
			m_CrouchDisableCollider.enabled = true;
            animator.SetBool("crouch", false);
            }
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

    {
        isOnGround = true;

    if (PlayerIsTrapped)
    {
       animator.SetBool("Trapped", true);
    }

    }
}