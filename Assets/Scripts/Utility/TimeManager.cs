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

    public float lestTime { get { return timeLimit - count; } }

	// Use this for initialization
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timeCount.text = (timeLimit - count).ToString();
        count += Time.deltaTime;
	}
}
