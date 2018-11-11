using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StockData : MonoBehaviour {
    public SerialHandller serialHandler;
    public Text text;
    public string[] datas;
    public float RValue;
    public float Xin;
    public float Yin;
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
            //           Debug.LogWarning("RValue1 : " + RValue);
            //           RValue = RValue * 4;
            //           Debug.LogWarning("RValue2 : "+RValue);
            text.text = "ResisterValue : " + RValue.ToString() + "\n" + "XIN : " + datas[1] + "\n" + "YIN : " + datas[2]; // シリアルの値をテキストに表示
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
