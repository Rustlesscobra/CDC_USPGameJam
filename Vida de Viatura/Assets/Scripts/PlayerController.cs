using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   
    public float transitionTime = 1.0f;
    public float PLAYER_BASE_SPEED = 1.0f;
    public Vector2 movementDirection;
    public float movementSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public Animator transition;
    void FixedUpdate()
    {
        ProcessInput();
        Move();
        Animate();
        
    }

    //public void GameOver() 
    //{
    //    GameOverScreen.Setup();
    //}

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
            bool flipped = movementDirection.x < 0;
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f: 0f, 0f));    
        }
        animator.SetFloat("Speed", movementSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(LoadLevel(2));
        }
    }
    
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
