using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemies
{
    private Animator animator;
    private Rigidbody2D rgb2D;
    private Transform slimeTransform;
    public float slimeMoveSpeed;



    public override void Awake()
    {
        base.Awake();
    }

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        animator = GetComponent<Animator>();
        rgb2D = GetComponent<Rigidbody2D>();
        slimeTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    public override void Update()
    {
        Vector3 playerDirection = playerTransform.transform.position - slimeTransform.transform.position;

        if (playerDirection.x < 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;

            rgb2D.AddForce(Vector2.left * slimeMoveSpeed, ForceMode2D.Impulse);
            rgb2D.AddForce(Vector2.up * slimeMoveSpeed, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
        else if (playerDirection.x > 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;

            rgb2D.AddForce(Vector2.right * slimeMoveSpeed, ForceMode2D.Impulse);
            rgb2D.AddForce(Vector2.up * slimeMoveSpeed, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }

        base.Update();
    }

    public override void AttackPlayer()
    {
        if (isPlayerToLeft())
        {
            //give slime horiz and verti mobility of 45 degrees to the left

            //call slimeAttack anim
            animator.SetTrigger("jump");
        }

        if (isPlayerToRight())
        {
            //give slime horiz and verti mobility of 45 degrees to the right

            //call slimeAttack anim
            animator.SetTrigger("jump");
        }
    }

    public override void MoveEnemy()
    {
        //do nothing - attack player handles movement and damage is dealt on contact
    }
}
