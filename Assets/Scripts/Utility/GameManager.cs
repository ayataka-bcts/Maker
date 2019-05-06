using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Enemy.EnemyManager enemyManager;
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
    [SerializeField]
    private Text scoreShoot;

    public int duration = 1;
    int count = 0;

    private bool _isSpawn = false;

    private bool _isPlaying = false;
    public static bool isPlaying = false;

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
        if ((int)timeManager.lestTime % duration == 0)
        {
            if (!_isSpawn)
            {
                int rnd = Random.Range(0, 5);
                enemyManager.Spawn(rnd);

                if (count > 0)
                {
                    _isSpawn = true;
                }

                count++;
            }
        }
        else
        {
            _isSpawn = false;
            count = 0;
        }
        
    }

    IEnumerator ChangeScore(int point)
    {
        this.gameObject.SetActive(true);

        if(point < 0)
        {
            scoreShoot.color = new Color(250, 51, 51); // 赤
            scoreShoot.text = "- " + point.ToString();
        }
        else if (point > 0)
        {
            scoreShoot.color = new Color(93, 255, 18); // 緑
            scoreShoot.text = "+ " + point.ToString();
        }

        yield return new WaitForSeconds(0.5f);

        this.gameObject.SetActive(false);
    }

    //タイプによって算出方法を分岐
    private void ScoreCululate(Enemy.EnemyType type){
        switch(type){
            case Enemy.EnemyType.SLOW:
                scoreManager.AddScore(20);
                //StartCoroutine(ChangeScore(10));
                break;
            case Enemy.EnemyType.FAST:
                scoreManager.AddScore(30);
                //StartCoroutine(ChangeScore(30));
                break;
            case Enemy.EnemyType.NPC:
                scoreManager.AddScore(-30);
                //StartCoroutine(ChangeScore(-30));
                break;
        }
                
        enemyManager.isDeadEnemy = false;
    }

	// Use this for initialization
	void Start () {
        isPlaying = false;
        SoundManager.Instance.PlayBgm("main");
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlaying)
        {
            // 敵のスポーン
            SpawnEnemy();

            // 敵を倒したときのスコア加算
            if (enemyManager.isDeadEnemy)
            {
                ScoreCululate(enemyManager.deadEnemy.enemyType);
            }

            // ゲーム終了処理
            if (timeManager.lestTime < 0)
            {
                GameSet();
                _isPlaying = false;
                TimeManager.isCountUp = false;
            }
        }
	}
}
