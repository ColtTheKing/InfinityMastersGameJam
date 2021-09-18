using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float jump;
    public float groundDistance = 0.4f;
    private bool isGrounded;

    private WeaponController weaponController;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        weaponController = GetComponent<WeaponController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //KEY HANDLING
        if (Input.GetKey("d"))
        {
            rb2d.velocity = new Vector2(2, 0);
        }
        else if (Input.GetKey("a"))
        {
            rb2d.velocity = new Vector2(-2, 0);
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
