using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour {

    [SerializeField]
    private TargetSightController targetSightController;

    [SerializeField]
    private GameObject Arduino;     //アルディーノの値を読めるように by Sakaki

    [SerializeField]
    private Image handStatus;

    [SerializeField]
    private Sprite[] sHandStatus;

    private bool _isSinglePlay = false;

    private void ManualModeChange()
    {
 //       if (Input.GetKeyDown(KeyCode.O))
        if (Arduino.GetComponent<StockData>().RValue <= 400)        //Arduino用
        {
            targetSightController.ChangePlayerState(PlayerStatus.PlayerState.NOSHAKEHAND);
            handStatus.sprite = sHandStatus[0];
        }
 //       if (Input.GetKeyDown(KeyCode.I))
        if (Arduino.GetComponent<StockData>().RValue > 400 && Arduino.GetComponent<StockData>().RValue <= 890)       //Arduino用
        {
            targetSightController.ChangePlayerState(PlayerStatus.PlayerState.SHAKEHAND);
            handStatus.sprite = sHandStatus[1];
        }
 //       if (Input.GetKeyDown(KeyCode.Z))
        if (Arduino.GetComponent<StockData>().RValue > 890)     //Arduino用
        {
            targetSightController.ChangePlayerState(PlayerStatus.PlayerState.HOLDHAND);
            handStatus.sprite = sHandStatus[2];
        }
    }

    private void SinglelPlay()
    {
        targetSightController.ChangePlayerState(PlayerStatus.PlayerState.SHAKEHAND);
        handStatus.sprite = sHandStatus[1];

    }

    private void DisplayGameStatus()
    {
        if (Input.GetKey(KeyCode.L))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _isSinglePlay = true;
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                _isSinglePlay = false;
            }
        }

        
    }

//#if UNITY_EDITOR
    // Use this for initialization
    void Start () {
        _isSinglePlay = false;
	}
	
	// Update is called once per frame
	void Update () {

        DisplayGameStatus();

        if (_isSinglePlay)
        {
            SinglelPlay();
        }
        else
        {
            ManualModeChange();
        }
   
    }
//#endif
}
