using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundMask;
    private Vector2 rightVector2;
    private Vector2 leftVector2;

    [HideInInspector] public bool left;
    [HideInInspector] public bool right;
    [HideInInspector] public bool isGrounded;
    public float fallMultipler = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float speed;

    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rightVector2.Set(4, 0);
        leftVector2.Set(-4, 0);
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
            rb2d.velocity = rightVector2.normalized * speed;
            rightVector2.y = -1.5f;
            rb2d.velocity = rightVector2;
        }
        
        if (left == true)
        {
            rb2d.velocity = leftVector2.normalized * speed;
            leftVector2.y = -1.5f;
            rb2d.velocity = leftVector2;
        }
        
        if(rb2d.velocity.y < 0)
        {
            rb2d.gravityScale = fallMultipler;
        }
        else if(rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space) && !isGrounded)
        {
            rb2d.gravityScale = lowJumpMultiplier;
        }
        else
        {
            rb2d.gravityScale = 1f;
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
