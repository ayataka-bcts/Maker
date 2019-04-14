using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] enemyPrefabs;

    // 敵が死んだことを通知する
    private bool _isDeadEnemy = false;
    public bool isDeadEnemy { get { return _isDeadEnemy; } set { _isDeadEnemy = false; } }

    // 敵の総数
    private int _enemyCount; 
    public int enemyCount { get { return _enemyCount; } set { _enemyCount = value; } }

    // 変更検知用の敵の数
    private int preEnemyCount;

    public void Spawn(int index)
    {
        int xPoint = Random.Range(-5, 5);
        int yPoint = Random.Range(-5, 5);
        Vector3 pos = new Vector3(xPoint, yPoint, 0);

        Instantiate(enemyPrefabs[index], pos, Quaternion.identity);
    }

	// Use this for initialization
	void Start () {
        _enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        preEnemyCount = _enemyCount;
	}
	 
	// Update is called once per frame
	void Update () {
        if(preEnemyCount != _enemyCount)
        {
            _isDeadEnemy = true;
        }
        preEnemyCount = _enemyCount;
    }
}
