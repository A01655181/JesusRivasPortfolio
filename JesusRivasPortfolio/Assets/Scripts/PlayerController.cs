using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO MAKE A DEDICATED SCRIPT FOR ANIMATION

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce; 
    private bool isJumping;
    private bool canJump;

    // ANIMATION VARIABLES
    [SerializeField] private Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();
        isJumping = false;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {

            Debug.Log("JUMP");
            isJumping = true;
            canJump = false;
        }
    }

    void FixedUpdate() {
        
        if(isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = false;
        }
        else if(isJumping == false)
        {
            rb.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
            
            if(rb.velocity.x > 0)
            {
                animatorController.SetBool("isMoving", true);
                FlipRight();
            }
            else if(rb.velocity.x < 0)
            {
                animatorController.SetBool("isMoving", true);
                FlipLeft();
            }
            else
            {
                animatorController.SetBool("isMoving", false);
            }
        }
    }

    private void FlipLeft()
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.flipX = true;
    }

    private void FlipRight()
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.flipX = false;
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Floor"))
        {
            canJump = true;
            isJumping = false;
        }
    }
}
