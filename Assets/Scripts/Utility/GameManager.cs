using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private EnemyManager enemyManager;
    [SerializeField]
    private GameObject gameSetObj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // ゲーム終了処理
		if(enemyManager.enemyCount == 0)
        {
            gameSetObj.SetActive(true);
        }
	}
}
