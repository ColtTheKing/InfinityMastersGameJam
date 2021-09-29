using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemies : MonoBehaviour
{
    public int moveSpeed;
    public int attackDamage;
    public int maxHealth;
    public float attackRadius;
    public int SECONDS_FOR_ENEMY_UPDATE;
    public Transform playerTransform;

    private float timer;

    protected int currentHealth;

    public virtual void Awake()
    {
        
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        timer = timer + 0.01f;
        if (timer >= SECONDS_FOR_ENEMY_UPDATE)
        {
            MoveEnemy();
            AttackPlayer();
            timer = 0;
        }
    }

    public float getXDistanceToPlayer()
    {
        //Negative is to the left, positive is to the right
        return playerTransform.position.x - transform.position.x;
    }

    public bool isPlayerToRight()
    {
        if (getXDistanceToPlayer() > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isPlayerToLeft()
    {
        if (0 >= getXDistanceToPlayer())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    abstract public void MoveEnemy();

    abstract public void AttackPlayer();

    public void TakeDamage(int dmg) //call this after player hits enemy
    {
        if ((currentHealth - dmg) > 0)
        {
            currentHealth -= dmg;
            //TODO play some sort of sound or anim to signify damage taken
            Debug.Log("health = " + currentHealth);
        }
        else
        {
            Die();
        }
    }


    void Die() //enemy dies
    {
        //delete enemy, play sound
        Destroy(gameObject);
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
        currentHealth = lp;
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
        return currentHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerHit = collision.collider.gameObject.GetComponent<PlayerController>();

        if (playerHit)
        {
            //try to damage the player
            playerHit.TakeDamage(attackDamage);
        }
    }
}