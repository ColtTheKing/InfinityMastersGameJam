using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon defaultWeapon1, defaultWeapon2;

    private Weapon weapon1, weapon2;
    private float timeUntilNextAttack;

    // Start is called before the first frame update
    void Start()
    {
        weapon1 = defaultWeapon1;
        weapon2 = defaultWeapon2;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntilNextAttack > 0)
            timeUntilNextAttack -= Time.deltaTime;
    }

    public void WeaponAttack(bool primaryWeapon, Animator animator)
    {
        if (timeUntilNextAttack <= 0)
        {
            if (primaryWeapon)
            {
                AttackHitbox hitbox = GetComponentInChildren<AttackHitbox>();

                hitbox.Activate();

                animator.SetTrigger("attack");

                timeUntilNextAttack = weapon1.cooldown;
            }
            else
            {
                //animator.SetTrigger("bomb");

                timeUntilNextAttack = weapon2.cooldown;
            }
        }
    }
}

