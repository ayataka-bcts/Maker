using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Enemy {
    public class ToughEnemy : BaseEnemy, IDamageable
    {

        // Use this for initialization
        void Start()
        {
            life = 3;
            speed = 1;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}