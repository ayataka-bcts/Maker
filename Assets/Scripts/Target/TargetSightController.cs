﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSightController : MonoBehaviour {

    private float distance = 50f;        // レイの飛距離(いじらなくてもいい)
    private float bulletPower = 1.0f;    // 銃の威力(1が標準)
    private int button_flag = 0;

    [SerializeField]
    private ParticleSystem flush;
    [SerializeField]
    private TargetSightView targetSightView;
    [SerializeField]
    private GameObject Arduino;     //アルディーノの値を読めるように by Sakaki
    [SerializeField]
    private RectTransform _rect;

    private PlayerStatus playerStatus;

	// Use this for initialization
	void Start () {
        playerStatus = new PlayerStatus();
	}
	
	// Update is called once per frame
	void Update () {

        // 射撃(スペースキー)
 //       if (Input.GetKeyDown(KeyCode.Space))
        if (Arduino.GetComponent<StockData>().Button == 1)        //Arduino用
        {
            // 手つなぎ状態のみ発砲可能
            if (playerStatus.playerState != PlayerStatus.PlayerState.NOSHAKEHAND && button_flag == 0)
            {
                Fire();

                //[TODO]TargetSightViewの関数を呼びたくない。
                StartCoroutine(targetSightView.FireView());

                button_flag = 1;
            }
            // 発砲できないときのエフェクト(SEで教えてあげるのがいいかな)
            else
            {
            
            }
        }
        else
        {
            button_flag = 0;
        }
    }

    void Fire()
    {
        SoundManager.Instance.PlaySe("fire");
        flush.Play();

        Vector2 localPos = Vector2.zero;
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, this.transform.position);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_rect, screenPos, Camera.main, out localPos);
        Ray ray = Camera.main.ScreenPointToRay(this.transform.position);
        //Ray ray = new Ray(this.transform.position, Vector3.forward);
        RaycastHit hit = new RaycastHit();
        Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);

        if (Physics.Raycast(ray, out hit, distance)){

            // ダメージ対象かどうか
            if (hit.collider.GetComponent<IDamageable>() != null)
            {
                // ダメージ処理
                hit.collider.GetComponent<IDamageable>().Damage(bulletPower);
            }

        }
    }

    public void ChangePlayerState(PlayerStatus.PlayerState state)
    {
        switch (state)
        {
            case PlayerStatus.PlayerState.NOSHAKEHAND:
                bulletPower = 0;
                targetSightView.sightSpeed = 8;
                playerStatus.playerState = PlayerStatus.PlayerState.NOSHAKEHAND;
                break;
            case PlayerStatus.PlayerState.SHAKEHAND:
                bulletPower = 1.0f;
                targetSightView.sightSpeed = 5;
                playerStatus.playerState = PlayerStatus.PlayerState.SHAKEHAND;
                break;
            case PlayerStatus.PlayerState.HOLDHAND:
                bulletPower = 2.0f;
                targetSightView.sightSpeed = 2;
                playerStatus.playerState = PlayerStatus.PlayerState.HOLDHAND;
                break;
        }
    }
}
