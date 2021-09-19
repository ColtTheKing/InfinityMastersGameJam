using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundMask;

    private bool left;
    private bool right;
    private bool isGrounded;
    public float fallMultipler = 2.5f;
    public float lowJumpMultiplier = 2f;
    

<<<<<<< HEAD
    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
=======
    private WeaponController weaponController;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        weaponController = GetComponent<WeaponController>();
>>>>>>> c44b6a2851cd2af90beec76676248194160e1b4a
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

<<<<<<< HEAD
        if (right == true)
        {
            rb2d.velocity = new Vector2(4, 0);
        }
        
        if (left == true)
        {
            rb2d.velocity = new Vector2(-4, 0);
        }
        
        if(rb2d.velocity.y < 0)
=======
        //KEY HANDLING
        if (Input.GetKey("d"))
>>>>>>> c44b6a2851cd2af90beec76676248194160e1b4a
        {
            rb2d.gravityScale = fallMultipler;
        }
        else if(rb2d.velocity.y > 0 && Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb2d.gravityScale = lowJumpMultiplier;
        }
        else
        {
            rb2d.gravityScale = 3f;
        }

    }

<<<<<<< HEAD
    private void Update()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }
        else
        {
            right = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        else
=======
        if (Input.GetKeyDown("space") && isGrounded == true)
>>>>>>> c44b6a2851cd2af90beec76676248194160e1b4a
        {
            left = false;
        }

        //MOUSE HANDLING
        if (Input.GetMouseButtonDown(0))
            ;
    }
}
