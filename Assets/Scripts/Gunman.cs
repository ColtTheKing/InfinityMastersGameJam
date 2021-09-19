using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Gunman : Enemies
    {
        private float reloadTimer;
        private float RETREAT_THRESHOLD; //if player is closer than this distance, gunman starts running
        private float SHOOT_MAX_RANGE; // maximum distance for gunman to shoot and hit


        BoxCollider2D hitBox;
        public override void AttackPlayer()
        {
            if (reloadTimer <= 0)
            {
                Shoot();
            }
            else reloadTimer = reloadTimer - 0.01f;
        }

        public override void MoveEnemy()
        {
            if (this.getXDistanceToPlayer() < RETREAT_THRESHOLD)//case one: BOOK IT!!!
            {
                if (isPlayerToLeft())
                {
                    
                }
                else
                {
                    //do slime movement but to the right
                }
            }

        }

        public void Retreat()
        {

        }

        public void Shoot()
        {
            //if { //dude in in range
                //delay/tick for a few seconds? for fairness
                //hitscan 
                //summon light (i can do this)
                //start reload timer once again
                //AAAAAAAAAAAAAHhttps://event.hackhub.com/event/BCGJ2021

            //}
        }

        public void Approach() { }


        // Use this for initialization
        void Start()
        {
            this.SECONDS_FOR_ENEMY_UPDATE = 1;
            this.attackDamage = 9;
            this.moveSpeed = 4;
            this.attackRadius = 5.0f;
            currentHealth = 22;
            this.reloadTimer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            base.Update();
        }
    }
}