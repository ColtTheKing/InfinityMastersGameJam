using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Transform groundCheck;
    public Transform groundCheck2;
    public LayerMask groundMask;
    public Image healthBarImage;
    
    [HideInInspector] public bool left;
    [HideInInspector] public bool right;
    public bool isGrounded;
    public float fallMultipler = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float speed;
    public float maxHp;
    public float invincibilityAfterDamage;

    private WeaponController weaponController;
    private Animator animator;
    private Vector2 rightVector2;
    private Vector2 leftVector2;
    private float currentHp;
    private float invincibilityTimer;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        weaponController = GetComponent<WeaponController>();
        animator = GetComponent<Animator>();

        rightVector2.Set(4, 0);
        leftVector2.Set(-4, 0);

        currentHp = maxHp;
        invincibilityTimer = 0;
    }

    void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck2.position, 1 << LayerMask.NameToLayer("Ground")) || Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            //If the player just landed, tell the animator to leave the jump animation
            if (!isGrounded)
                animator.SetTrigger("land");

            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (right == true)
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
        if (invincibilityTimer > 0)
            invincibilityTimer -= Time.deltaTime;

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
            weaponController.WeaponAttack(true, animator);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            weaponController.WeaponAttack(false, animator);
        }
    }

    public void TakeDamage(float dmg)
    {
        if (invincibilityTimer > 0)
            return;

        if ((currentHp - dmg) > 0)
        {
            currentHp -= dmg;
            //TODO play some sort of sound or anim to signify damage taken
            Debug.Log("player health = " + currentHp);

            //Set health bar
            healthBarImage.fillAmount = currentHp / maxHp;

            //Give the player I-frames after being damaged
            invincibilityTimer = invincibilityAfterDamage;
        }
        else
        {
            Die();

            //Set health bar to none
            healthBarImage.fillAmount = 0;
        }
    }

    private void Die()
    {
        //Game over
        Debug.Log("ded");
    }
}