using UnityEngine;
using System.Collections;

public class WeccameraCapture : MonoBehaviour {
    private WebCamTexture webcamtex;
    // Use this for initialization
    void Start()
    {
        webcamtex = new WebCamTexture();   //コンストラクタ

        Renderer _renderer = GetComponent<Renderer>();  //Planeオブジェクトのレンダラ
        _renderer.material.mainTexture = webcamtex;    //mainTextureにWebCamTextureを指定
        webcamtex.Play();  //ウェブカムを作動させる
    }

    // Update is called once per frame
    void Update()
    {

    }

}
