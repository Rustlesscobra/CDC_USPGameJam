using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PLAYER_BASE_SPEED = 1.0f;
    public Vector2 movementDirection;
    public float movementSpeed;
    public Rigidbody2D rb;
    void FixedUpdate()
    {
        ProcessInput();
        Move();
    }
    void ProcessInput() 
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize(); 
    }
    
    void Move ()
    {
        rb.velocity = movementDirection * movementSpeed * PLAYER_BASE_SPEED;
    }
}
