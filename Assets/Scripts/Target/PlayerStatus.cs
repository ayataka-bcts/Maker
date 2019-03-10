using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public enum PlayerState
    {
        SHAKEHAND,
        NEAUTORAL,
    }

    private PlayerState _playerState;
    public PlayerState playerState;

	// Use this for initialization
	void Start () {
        _playerState = PlayerState.NEAUTORAL;	
	}
	
}
