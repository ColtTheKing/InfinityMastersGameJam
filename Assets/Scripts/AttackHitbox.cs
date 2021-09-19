using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;
    [SerializeField]
    private float hitboxDelay;
    [SerializeField]
    private float hitboxDuration;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!active)
            return;

        Enemies enemyHit = collision.otherCollider.gameObject.GetComponent<Enemies>();

        if (enemyHit)
        {
            //deal damage to enemy = weapon.damage
        }
    }
}
