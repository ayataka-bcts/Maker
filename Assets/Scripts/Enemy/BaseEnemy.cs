using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public abstract class BaseEnemy : MonoBehaviour, IDamageable
    {

        protected int life;
        protected int speed;
        protected bool isDead = false;

        public void Damage()
        {
            life--;

            // 死んだかどうかの判定
            if (life < 0)
            {
                isDead = true;
                Dead();
            }
        }

        public void Dead()
        {
            if (isDead)
            {
                Destroy(this.gameObject);
            }
        }
    }
}