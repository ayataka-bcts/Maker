using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class SamuraiEnemy : BaseEnemy
    {

        new void Move()
        {
            var pos = this.transform.position;
            pos.z -= Time.deltaTime * speed;
            this.transform.position = pos;
        }

        // Use this for initialization
        void Start()
        {
            speed = 0.8f;
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