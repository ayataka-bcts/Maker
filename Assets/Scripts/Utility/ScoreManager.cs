using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    [SerializeField]
    private Text scoreText;

    private int _score;
    public int score { get { return _score; } }  

	// Use this for initialization
	void Start () {
        InitializeScore();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void InitializeScore()
    {
        _score = 0;
        DisplayScore();
    }

    public void DisplayScore()
    {
        if(_score < 0){
            _score = 0;
        }
            
        scoreText.text = _score.ToString();
    }

    public void AddScore(int point)
    {
        _score += point;
        DisplayScore();
    }

    public void MinusScore(int point){
        _score -= point;
        DisplayScore();
    }
}
