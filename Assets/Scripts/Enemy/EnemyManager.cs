using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    // 敵の総数
    private int _enemyCount; 
    public int enemyCount { get { return _enemyCount; } set { _enemyCount = value; } }

	// Use this for initialization
	void Start () {
        _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
	}
	
	// Update is called once per frame
	void Update () {
    }
}
