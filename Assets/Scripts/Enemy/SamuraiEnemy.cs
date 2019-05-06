using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class SamuraiEnemy : BaseEnemy
    {
        // Use this for initialization
        void Start()
        {
            enemyType = EnemyType.SLOW;
            speed = 1.0f;
            life = 2;
            enemyManager = this.transform.parent.GetComponent<EnemyManager>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }
    }

}