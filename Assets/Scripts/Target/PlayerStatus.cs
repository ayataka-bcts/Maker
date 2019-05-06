using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus {

    // プレイヤー(銃)のモード
    // (int)でキャストして変数modeに格納が可能です
    // enumにしておくと状態変数が後々増えたとしても対応付けがわかりやすいのでこっちで管理しています
    public enum PlayerState
    {
        NOSHAKEHAND = 0,
        SHAKEHAND = 1,
        HOLDHAND = 2,
    }

    private PlayerState _playerState;
    public PlayerState playerState;

	// Use this for initialization
	public PlayerStatus() {
        _playerState = PlayerState.NOSHAKEHAND;	
	}
	
}
