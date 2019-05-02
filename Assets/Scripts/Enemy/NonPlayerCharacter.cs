using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
	public class NonPlayerCharacter : BaseEnemy {

	// Use this for initialization
	void Start () {
		enemyType = EnemyType.NPC;
		speed = 0.8f;
        life = 1;
        enemyManager = this.transform.parent.GetComponent<EnemyManager>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}
}

}
