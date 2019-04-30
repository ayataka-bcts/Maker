using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private EnemyManager enemyManager;
    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField]
    private TimeManager timeManager;

    [SerializeField]
    private GameObject fadePannel;
    [SerializeField]
    private GameObject gameSetObj;
    [SerializeField]
    private Text ResultScore;

    private bool _isSpawn = false;

    private bool _isPlaying = false;

    public void ResultButton(string sceneName)
    {
        StartCoroutine(SceneTransition(sceneName));
    }

    private IEnumerator SceneTransition(string sceneName)
    {
        fadePannel.SetActive(true);

        fadePannel.GetComponent<Animator>().SetTrigger("_isStart");

        SoundManager.Instance.PlaySe("button");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(sceneName);
    }

    // ゲームセット時の処理
    private void GameSet()
    {
        gameSetObj.SetActive(true);
        ResultScore.text = scoreManager.score.ToString();
    }

    // 敵のスポーン
    private void SpawnEnemy()
    {
        if ((int)timeManager.lestTime % 3 == 0)
        {
            if (!_isSpawn)
            {
                int rnd = Random.Range(0, 2);
                enemyManager.Spawn(rnd);

                _isSpawn = true;
            }
        }
        else
        {
            _isSpawn = false;
        }
        
    }

	// Use this for initialization
	void Start () {
        _isPlaying = true;

        SoundManager.Instance.PlayBgm("main");
	}
	
	// Update is called once per frame
	void Update () {
        if (_isPlaying)
        {
            // 敵のスポーン
            SpawnEnemy();

            // 敵を倒したときのスコア加算
            if (enemyManager.isDeadEnemy)
            {
                scoreManager.AddScore(10);
                enemyManager.isDeadEnemy = false;
            }

            // ゲーム終了処理
            if (timeManager.lestTime < 0)
            {
                GameSet();
                _isPlaying = false;
                timeManager.isCountUp = false;
            }
        }
	}
}
