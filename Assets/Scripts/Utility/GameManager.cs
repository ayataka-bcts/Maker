using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private EnemyManager enemyManager;
    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField]
    private TimeManager timeManager;
    [SerializeField]
    private GameObject gameSetObj;
    [SerializeField]
    private Text ResultScore;

    private void GameSet()
    {
        gameSetObj.SetActive(true);
        ResultScore.text = scoreManager.score.ToString();
    }

    private void SpawnEnemy()
    {
        int rnd = Random.Range(0, 2);

        enemyManager.Spawn(rnd);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // 敵のスポーン
        if(timeManager.lestTime % 5 == 0)
        {
            SpawnEnemy();
        }

        // 敵を倒したときのスコア加算
        if (enemyManager.isDeadEnemy)
        {
            scoreManager.AddScore(10);
            enemyManager.isDeadEnemy = false;
        }

        // ゲーム終了処理
		if(timeManager.lestTime < 0 )
        {
            GameSet();
        }
	}
}
