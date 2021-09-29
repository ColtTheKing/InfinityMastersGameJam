using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    public Weapon weapon;
    public float hitboxDelay;
    public float hitboxDuration;

    private float hitboxTimer;
    private bool attackInProgress;
    private BoxCollider2D attackCollider;

    // Start is called before the first frame update
    void Start()
    {
        attackCollider = GetComponent<BoxCollider2D>();
        attackCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackInProgress)
        {
            hitboxTimer += Time.deltaTime;
            
            if (!attackCollider.enabled && hitboxTimer >= hitboxDelay)
            {
                //If the delay has passed, activate the hitbox
                attackCollider.enabled = true;

            }
            else if (attackCollider.enabled && hitboxTimer > hitboxDelay + hitboxDuration)
            {
                //If the hitbox duration has passed, deactivate the hitbox and stop the attack
                attackCollider.enabled = false;
                attackInProgress = false;
            }
        }
    }

    public void Activate()
    {
        attackInProgress = true;
        hitboxTimer = 0;
    }

    public void OnTriggerEnter2D(Collider2D enemyCollider)
    {
        Enemies enemyHit = enemyCollider.gameObject.GetComponent<Enemies>();

        if (enemyHit)
        {
            enemyHit.TakeDamage(weapon.damage);
        }
    }
}
