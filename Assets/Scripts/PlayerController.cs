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
    

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (right == true)
        {
            rb2d.velocity = new Vector2(4, 0);
        }
        
        if (left == true)
        {
            rb2d.velocity = new Vector2(-4, 0);
        }
        
        if(rb2d.velocity.y < 0)
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
        {
            left = false;
        }
    }
}
