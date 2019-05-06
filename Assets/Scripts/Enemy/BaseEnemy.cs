using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public abstract class BaseEnemy : MonoBehaviour, IDamageable
    {
        protected int life;                     // 耐久力
        protected float speed;                  // 移動速度
        public bool isDead {get; private set;}  // 生死
        public EnemyType enemyType {get; protected set;}
        protected EnemyManager enemyManager;
        private Vector2 targetPos;

        /// <summary>
        /// 死んだ時の処理一連
        /// </summary>
        private IEnumerator DeadSequence(){

            if(enemyType == EnemyType.NPC){

                this.GetComponent<Animator>().SetTrigger("_isDead");

                SoundManager.Instance.PlaySe("cancel");

                yield return new WaitForSeconds(1.0f);

            }
            else
            {
                yield return null;

                SoundManager.Instance.PlaySe("button");
            }

            Dead();
        }

        /// <summary>
        /// 撃たれた時の処理
        /// </summary>
        public void Damage(float damage)
        {
            life -= (int)damage;

            // 死んだかどうかの判定
            if (life <= 0)
            {
                enemyManager.enemyCount--;
                isDead = true;
                StartCoroutine(DeadSequence());
            }
        }

        /// <summary>
        ///  死んだときの処理
        /// </summary>
        public void Dead()
        {
            if (isDead)
            {
                isDead = false;
                Destroy(this.gameObject);
            }
        }

        /// <summary>
        /// 自動で移動する処理
        /// </summary>
        protected void Move()
        {
            var pos = this.transform.position;
            pos.z -= Time.deltaTime * speed;
            this.transform.position = pos;
        }

        // 以下仮実装なので消すかも

        protected void TargetPositioning()
        {
            targetPos.x = Random.Range(-1.0f, 1.0f);
            targetPos.y = Random.Range(-1.0f, 1.0f);
        }



    }
}