using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public abstract class BaseEnemy : MonoBehaviour, IDamageable
    {
        protected int life;
        protected float speed;
        protected bool isDead = false;
        protected EnemyManager enemyManager;
        private Vector2 targetPos;

        /// <summary>
        /// 撃たれた時の処理
        /// </summary>
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

        /// <summary>
        ///  死んだときの処理
        /// </summary>
        public void Dead()
        {
            if (isDead)
            {
                Destroy(this.gameObject);
                enemyManager.enemyCount--;
            }
        }

        /// <summary>
        /// 自動で移動する処理
        /// </summary>
        protected void Move()
        {
            Vector3 pos = transform.position;
            pos.x += targetPos.x * speed;
            pos.y += targetPos.y * speed;
            transform.position = pos;
        }

        protected void TargetPositioning()
        {
            targetPos.x = Random.Range(-1.0f, 1.0f);
            targetPos.y = Random.Range(-1.0f, 1.0f);
        }
    }
}