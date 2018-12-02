using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakingSight : MonoBehaviour {

    [SerializeField]
    private int shakeRange = 10;             // 手ブレの範囲(大きさ)
    [SerializeField]
    private float shakeDuration = 0.1f;      // 手ブレの間隔(s)

    private float timeCount = 0;             // 経過時間

    private void Start()
    {
        timeCount = 0;
    }

    /// <summary>
    /// Vector2を受け取ってshakeRange分だけランダムでブレさせる
    /// </summary>
    public Vector3 Shake(Vector3 mPos)
    {
        if (timeCount > shakeDuration)
        {
            mPos.x += Random.Range(-shakeRange, shakeRange);
            mPos.y += Random.Range(-shakeRange, shakeRange);

            timeCount = 0;

        }


        timeCount += Time.deltaTime;

        return mPos;
    }
}
