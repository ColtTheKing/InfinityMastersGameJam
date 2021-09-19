using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float jump;
    private bool isGrounded;

    private WeaponController weaponController;
    private Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        weaponController = GetComponent<WeaponController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //KEY HANDLING
        if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(2, 0);

            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-2, 0);

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
        }

        //MOUSE HANDLING
        if (Input.GetMouseButtonDown(0))
            ;
    }
}
