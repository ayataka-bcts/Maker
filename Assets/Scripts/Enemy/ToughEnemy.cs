using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy {
    public class ToughEnemy : BaseEnemy, IDamageable
    {
        float time = 2.0f;

        // Use this for initialization
        void Start()
        {
            enemyManager = this.transform.parent.GetComponent<EnemyManager>();

            life = 3;
            speed = 0.02f;
        }

        // Update is called once per frame
        void Update()
        {
            if(time > 2.0f)
            {
                TargetPositioning();
                time = 0f;
            }

            Move();
            time += Time.deltaTime;
        }
    }
}