using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemies
{
    private Animator animator;

    public override void Awake()
    {
        base.Awake();

        //SECONDS_FOR_ENEMY_UPDATE = 3;
        //attackDamage = 4;
        //moveSpeed = 1;
        //attackRadius = 0.5f;
        //maxHealth = 8;
    }

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {
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
