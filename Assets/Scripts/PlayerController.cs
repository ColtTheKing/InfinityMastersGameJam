using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Transform groundCheck;
    public LayerMask groundMask;
    private Vector2 rightVector2;
    private Vector2 leftVector2;

    [HideInInspector] public bool left;
    [HideInInspector] public bool right;
    [HideInInspector] public bool isGrounded;
    public float fallMultipler = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float speed;
    public float maxBugFloat;

    private WeaponController weaponController;
    private Animator animator;
    private SpriteRenderer playerSprite;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        weaponController = GetComponent<WeaponController>();
        animator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();

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
        Debug.DrawLine(transform.position, groundCheck.position);

        if(right == true)
        {

            animator.SetBool("isWalking", true);

            rb2d.AddForce(rightVector2.normalized * speed);
            rightVector2.y = rb2d.velocity.y;
            rb2d.velocity = rightVector2;
        }

        if (left == true)
        {

            rb2d.AddForce(leftVector2.normalized * speed);
            leftVector2.y = rb2d.velocity.y;
            rb2d.velocity = leftVector2;
        }

        if (!left && !right)
        {
            animator.SetBool("isWalking", false);
        }

        if (rb2d.velocity.y < 0)
        {
            rb2d.gravityScale = fallMultipler;
        }
        else if (rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space) && !isGrounded)
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
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            right = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            left = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            left = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            weaponController.WeaponAttack();
            animator.SetTrigger("attack");
        }
    }
}
