using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public Weapon weapon;
    public float hitboxDelay;
    public float hitboxDuration;

    private float hitboxTimer;
    private bool hitboxActive, attackInProgress;

    // Start is called before the first frame update
    void Start()
    {
        //BoxCollider2D collider = GetComponent<BoxCollider2D>();
        //collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackInProgress)
        {
            hitboxTimer += Time.deltaTime;
            
            if (!hitboxActive && hitboxTimer >= hitboxDelay)
            {
                //If the delay has passed, activate the hitbox
                hitboxActive = true;
                //BoxCollider2D collider = GetComponent<BoxCollider2D>();
                //collider.enabled = true;

            }
            else if (hitboxActive && hitboxTimer > hitboxDelay + hitboxDuration)
            {
                //If the hitbox duration has passed, deactivate the hitbox and stop the attack
                hitboxActive = false;
                //BoxCollider2D collider = GetComponent<BoxCollider2D>();
                //collider.enabled = false;

                attackInProgress = false;
            }
        }
    }

    public void Activate()
    {
        attackInProgress = true;
        hitboxTimer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hitboxActive)
            return;

        Enemies enemyHit = collision.otherCollider.gameObject.GetComponent<Enemies>();

        if (enemyHit)
        {
            enemyHit.TakeDamage(weapon.damage);
        }
    }
}
