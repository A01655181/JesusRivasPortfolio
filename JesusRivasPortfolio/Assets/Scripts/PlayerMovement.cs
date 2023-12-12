using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {
        movement = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        float HMovement = Input.GetAxis("Horizontal");
        float VMovement = Input.GetAxis("Vertical");

        movement.x = HMovement;
        movement.y = VMovement;
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
