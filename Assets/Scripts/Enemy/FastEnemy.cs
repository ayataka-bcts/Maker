using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class FastEnemy : BaseEnemy
    {
        // Use this for initialization
        void Start()
        {
            enemyType = EnemyType.FAST;
            speed = 2f;
            life = 1;
            enemyManager = this.transform.parent.GetComponent<EnemyManager>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }
    }

}