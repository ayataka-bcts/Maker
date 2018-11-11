﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSightView : MonoBehaviour {

    [SerializeField]
    private ShakingSight shakingSight;      // 手ブレのためのクラス

    [SerializeField]
    private GameObject Arduino;

    public static float xin;
    public static float yin;

    float speed = 1.0f;

    private Image _image;                   // 照準の画像

    /// <summary>
    /// マウスで動かす
    /// </summary>
    private void SightMove()
    {
        // マウスの座標(xyのみ)を反映
        var mousePos = Input.mousePosition;
        mousePos.z = this.transform.position.z;
        this.transform.position = shakingSight.Shake(mousePos);
    }

    /// <summary>
    /// アナログスティックでの移動
    /// </summary>
    private void StickMove()
    {
        xin = Arduino.GetComponent<StockData>().Xin;
        yin = Arduino.GetComponent<StockData>().Yin;

        //アナログスティック使用時
        xin = (xin - 513.0f) / 258.5f;
        yin = (yin - 510.0f) / 253.0f;
        if (xin >= -0.05f && xin <= 0.05f)
        {
            xin = 0.0f;
        }
        if (yin >= -0.05f && yin <= 0.05f)
        {
            yin = 0.0f;
        }

        //アナログスティック
        Vector3 direction = Vector3.up * yin + Vector3.right * xin;
        Vector3 playerdir = direction;

        //現在の位置＋入力した数値の場所に移動する
        this.transform.position = this.transform.position + direction * speed;
    }

	void Start () {
        _image = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        // 照準移動処理(マウス)
        //SightMove();

        // 照準移動処理(スティック)
        StickMove();
	}

    // 発砲してるときの見た目
    public IEnumerator FireView()
    {
        _image.color = Color.red;

        yield return new WaitForSeconds(0.5f);

        _image.color = Color.white;
    }
}
