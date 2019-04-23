using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StockData : MonoBehaviour {
    public SerialHandller serialHandler;
    public Text text;
    public string[] datas;
    public float RValue;        //手を繋いだ時の抵抗の割合
    public float Xin;           //スティック入力X
    public float Yin;           //スティック入力Y
    public int Button;          //トリガー
    public float BPM_P1;        //BPM プレイヤー1
    public float BPM_P2;
    // Use this for initialization
    void Start () {
        serialHandler.OnDataReceived += OnDataReceived;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnDataReceived(string message)
    {
        //       RValue = float.Parse(message);
        datas = message.Split(',');

        //               Debug.LogWarning("Handshake");
        try
        {
            RValue = float.Parse(datas[0]) * 4;
            Xin = float.Parse(datas[1]);
            Yin = float.Parse(datas[2]);
            Button = int.Parse(datas[7]);
            BPM_P1 = float.Parse(datas[4]);
            BPM_P2 = float.Parse(datas[6]);
            //           Debug.LogWarning("RValue1 : " + RValue);
            //           RValue = RValue * 4;
            //           Debug.LogWarning("RValue2 : "+RValue);
            text.text = "ResisterValue : " + RValue.ToString() + "\n" + "XIN : " + datas[1] + "\n" + "YIN : " + datas[2] + "\n" + "button : " + datas[7]; // シリアルの値をテキストに表示
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
        //        Debug.LogWarning("RValue2 : " + RValue);
        //              Debug.LogWarning("Rvalue : "+ RValue);
    }

    //   public static float getRvalue()
    //   {
    //       return Rvalue2;
    //   }
}
