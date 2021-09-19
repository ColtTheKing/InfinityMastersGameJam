using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemies
    : MonoBehaviour
{
    public float timer;
    public int moveSpeed;
    public int attackDamage;
    public int healthPoints;
    public float attackRadius;
    public int SECONDS_FOR_ENEMY_UPDATE;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        timer = timer + 0.01f;
        if (timer >= SECONDS_FOR_ENEMY_UPDATE)
        {
            MoveEnemy();
            AttackPlayer();
            TakeDamage(0);
            Debug.Log("Enemy ticked!");
            timer = 0;
        }
    }

    abstract public void MoveEnemy();

    abstract public void AttackPlayer();
 

    void TakeDamage(int dmg) //call this after player hits enemy
    {
        if ((this.healthPoints - dmg) > 0)
        {
            this.healthPoints = this.healthPoints - dmg;
            //TODO play some sort of sound or anim to signify damage taken
        }
        else
        {
            this.Die();
        }
    }


    void Die() //enemy dies
    {
        //delete enemy, play sound
    }

    public void setMoveSpeed(int speed)
    {
        moveSpeed = speed;
    }

    public void setAttackDamage(int attdmg)
    {
        attackDamage = attdmg;
    }

    public void setHealthPoints(int lp)
    {
        healthPoints = lp;
    }

    public int getMoveSpeed()
    {
        return moveSpeed;
    }

    public int getAttackDamage()
    {
        return attackDamage;
    }

    public int getHealthPoints()
    {
        return healthPoints;
    }
}