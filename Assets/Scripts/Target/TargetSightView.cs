using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSightView : MonoBehaviour {

    [SerializeField]
    private ShakingSight shakingSight;      // 手ブレのためのクラス

    private Image _image;                   // 照準の画像
    public float sightSpeed = 100.0f;        // 照準の移動速度

    [SerializeField]
    private GameObject Arduino;

    public static float xin;
    public static float yin;

    float speed = 1.0f;

    /// <summary>
    /// マウスで動かす
    /// </summary>
    private void MouseMove()
    {
        // マウスの座標(xyのみ)を反映
        var mousePos = Input.mousePosition;
        mousePos.z = this.transform.position.z;
        this.transform.position = shakingSight.Shake(mousePos);
    }

    ///<summary>
    /// キーボード入力で操作(AWSD)
    /// </summary>
    private void ButtonMove()
    {
        var nowPos = this.transform.localPosition;
        
        if (Input.GetKey(KeyCode.W))
        {
            nowPos.y += Time.deltaTime * sightSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            nowPos.y -= Time.deltaTime * sightSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            nowPos.x -= Time.deltaTime * sightSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            nowPos.x += Time.deltaTime * sightSpeed;
        }

        this.transform.localPosition = shakingSight.Shake(nowPos);
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
        yin = (yin - 510.0f) / -253.0f;
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
        this.transform.localPosition = shakingSight.Shake(this.transform.position + direction * speed);
    }

	void Start () {
        _image = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        // 照準移動処理(マウス)
        //MouseMove();

        // 照準移動(ボタン)
        ButtonMove();

        // 照準移動処理(スティック)
        //StickMove();
	}

    // 発砲してるときの見た目
    public IEnumerator FireView()
    {
        _image.color = Color.red;

        yield return new WaitForSeconds(0.5f);

        _image.color = Color.white;
    }
}
