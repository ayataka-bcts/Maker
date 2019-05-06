using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] enemyPrefabs;
    private List<GameObject> aliveEnemys = new List<GameObject>();

    public BaseEnemy deadEnemy { get; private set;}

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
        float xPoint = Random.Range(-3.0f, 3.0f);
        Vector3 pos = new Vector3(xPoint, -0.3f, 1.5f);

        Quaternion rot = Quaternion.identity;
        rot = Quaternion.Euler(0, 180, 0);

        aliveEnemys.Add(Instantiate(enemyPrefabs[index], pos, rot) as GameObject);
        aliveEnemys[aliveEnemys.Count - 1].transform.parent = this.transform;
        _enemyCount++;
    }

	// Use this for initialization
	void Start () {
        var enemys = GameObject.FindGameObjectsWithTag("Enemy");
        _enemyCount = enemys.Length;
        preEnemyCount = _enemyCount;
	}
	 
	// Update is called once per frame
	void Update () {

        if(preEnemyCount != _enemyCount){
            for(int i = 0; i < aliveEnemys.Count; i++){
                if(aliveEnemys[i] != null){
                    if(aliveEnemys[i].GetComponent<BaseEnemy>().isDead){
                        deadEnemy = aliveEnemys[i].GetComponent<BaseEnemy>();
                        _isDeadEnemy = true;
                        aliveEnemys.RemoveAt(i);
                    }
                }
            }
        }

        preEnemyCount = _enemyCount;
    }
}

}
