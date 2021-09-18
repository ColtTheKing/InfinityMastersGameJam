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

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        weaponController = GetComponent<WeaponController>();
    }

    void FixedUpdate()
    {
<<<<<<< HEAD
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //KEY HANDLING
=======
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
>>>>>>> 02ef720a9afe22f9b5570f525d370d8bd07e816c
        if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(2, 0);
        }
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-2, 0);
        }

        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
        }
    }
}
