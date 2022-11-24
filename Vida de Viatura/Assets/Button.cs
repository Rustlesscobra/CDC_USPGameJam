using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Collider2D col;
    public Animator animator;
    public GameObject door;
    [SerializeField] private ButtonType buttonType;
    public enum ButtonType
    {
        zero,
        one,
        two,
        three
    }

    void Start ()
    {
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            animator.SetTrigger("Pressed");
            door.SetActive(false);
            col.enabled = false;
        }
    }
}
