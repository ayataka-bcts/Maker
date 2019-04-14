using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] enemyPrefabs;

    // 敵の総数
    private int _enemyCount; 
    public int enemyCount { get { return _enemyCount; } set { _enemyCount = value; } }

    private void Spawn(GameObject enemy)
    {
        Instantiate(enemy);
    }

	// Use this for initialization
	void Start () {
        _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
	}
	
	// Update is called once per frame
	void Update () {
    }
}
