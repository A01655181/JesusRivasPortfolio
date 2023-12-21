using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce; 
    private Vector2 movement;
    private bool isJumping;
    private bool canJump;


    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector2();
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        float HMovement = Input.GetAxisRaw("Horizontal");
        //float VMovement = Input.GetAxis("Vertical");

        movement.x = HMovement;
        //movement.y = VMovement;
    
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
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = false;
        }
        else if(isJumping == false)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Floor"))
        {
            canJump = true;
            isJumping = false;
        }
    }
}
