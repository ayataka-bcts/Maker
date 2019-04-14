using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class FastEnemy : BaseEnemy
    {
        float time = 2.0f;

        // Use this for initialization
        void Start()
        {
            life = 1;
            speed = 0.04f;
            enemyManager = this.transform.parent.GetComponent<EnemyManager>();
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