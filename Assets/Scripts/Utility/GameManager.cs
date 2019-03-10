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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // ゲーム終了処理
		if(enemyManager.enemyCount == 0 || timeManager.lestTime < 0 )
        {
            GameSet();
        }
	}
}
