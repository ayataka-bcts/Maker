using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSightController : MonoBehaviour {

    private float distance = 50f;        // レイの飛距離(いじらなくてもいい)
    private float bulletPower = 1.0f;    // 銃の威力(1が標準)

    [SerializeField]
    private TargetSightView targetSightView;
    private PlayerStatus playerStatus;

	// Use this for initialization
	void Start () {
        playerStatus = new PlayerStatus();
	}
	
	// Update is called once per frame
	void Update () {

        // 射撃(スペースキー)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 手つなぎ状態のみ発砲可能
            if (playerStatus.playerState != PlayerStatus.PlayerState.NEAUTORAL)
            {
                Fire();

                //[TODO]TargetSightViewの関数を呼びたくない。
                StartCoroutine(targetSightView.FireView());
            }
            // 発砲できないときのエフェクト(SEで教えてあげるのがいいかな)
            else
            {

            }
        }
    }

    void Fire()
    {
        SoundManager.Instance.PlaySe("fire");

        Ray ray = Camera.main.ScreenPointToRay(this.transform.position);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit, distance)){

            // ダメージ対象かどうか
            if (hit.collider.GetComponent<IDamageable>() != null)
            {
                // ダメージ処理
                hit.collider.GetComponent<IDamageable>().Damage();
            }
        }
    }

    public void ChangePlayerState(PlayerStatus.PlayerState state)
    {
        switch (state)
        {
            case PlayerStatus.PlayerState.NEAUTORAL:
                bulletPower = 0;
                targetSightView.sightSpeed = 100;
                playerStatus.playerState = PlayerStatus.PlayerState.NEAUTORAL;
                break;
            case PlayerStatus.PlayerState.SHAKEHAND:
                bulletPower = 2.0f;
                targetSightView.sightSpeed = 50;
                playerStatus.playerState = PlayerStatus.PlayerState.SHAKEHAND;
                break;
            case PlayerStatus.PlayerState.NOSHAKEHAND:
                bulletPower = 1.0f;
                targetSightView.sightSpeed = 200;
                playerStatus.playerState = PlayerStatus.PlayerState.NOSHAKEHAND;
                break;
        }
    }
}
