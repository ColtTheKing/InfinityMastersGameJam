using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Transform groundCheck;


    private bool isGrounded;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
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
        if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(2, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-2, 0);
        }

        //if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        //{
        //rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
        //isGrounded = false;
        //}

        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.x * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }
}
