using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    [SerializeField]
    private Text timeCount;             // 表示用テキスト

    [SerializeField]
    private int timeLimit = 30;         // 制限時間

    private float count = 0;            // 経過時間

    public float lestTime { get { return timeLimit - count; } }     // 残り時間

    private bool _isCountUp = false;
    public bool isCountUp { set { _isCountUp = value; } }

    public void StopCount()
    {

    }

	// Use this for initialization
	void Start () {
        count = 0;
        _isCountUp = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (_isCountUp)
        {
            timeCount.text = (timeLimit - count).ToString();
            count += Time.deltaTime;
        }
	}
}
