using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSightView : MonoBehaviour {

    private Image _image;

    private void SightMove()
    {
        // マウスの座標(xyのみ)を反映
        var mousePos = Input.mousePosition;
        mousePos.z = this.transform.position.z;
        this.transform.position = mousePos;
    }

	void Start () {
        _image = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        // 照準移動処理
        SightMove();
	}

    // 発砲してるときの見た目
    public IEnumerator FireView()
    {
        _image.color = Color.red;

        yield return new WaitForSeconds(0.5f);

        _image.color = Color.white;
    }
}
