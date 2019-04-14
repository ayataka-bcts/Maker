using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour {

    [SerializeField]
    private TargetSightController targetSightController;

    private void ManualModeChange()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            targetSightController.ChangePlayerState(PlayerStatus.PlayerState.NEAUTORAL);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            targetSightController.ChangePlayerState(PlayerStatus.PlayerState.SHAKEHAND);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            targetSightController.ChangePlayerState(PlayerStatus.PlayerState.NOSHAKEHAND);
        }
    }

    private void DisplayGameStatus()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (Input.GetKeyDown(KeyCode.M))
            {

            }
        }
    }

#if UNITY_EDITOR
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        ManualModeChange();
   
    }
#endif
}
