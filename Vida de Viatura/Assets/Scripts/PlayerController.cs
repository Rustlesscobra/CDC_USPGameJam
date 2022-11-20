using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PLAYER_BASE_SPEED = 1.0f;
    public Vector2 movementDirection;
    public float movementSpeed;
    public Rigidbody2D rb;
    public Animator animator;

    void FixedUpdate()
    {
        ProcessInput();
        Move();
        Animate();
        
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

    void Animate ()
    {
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
            bool flipped = movementDirection.x > 0;
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f: 0f, 0f));    
        }
        animator.SetFloat("Speed", movementSpeed);
    }
}
