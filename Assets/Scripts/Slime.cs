using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Slime : Enemies
    {
        public override void AttackPlayer()
        {
            // if (distancetoplayer<=0) and las
            // deal this.attackDamage to player
            //
        }

        public override void MoveEnemy()
        {
            
        }

        // Use this for initialization
        void Start()
        {
            this.SECONDS_FOR_ENEMY_UPDATE = 3;
            this.attackDamage = 4;
            this.moveSpeed = 1;
            this.attackRadius = 0.5f;
            this.healthPoints = 8;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}