using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDroneAnimatorControl 
{
    private PlayerDronnControl _playerControl;

    public void Init(PlayerDronnControl control)
    {
        _playerControl = control;
    }


    public void Idle()
    {
        _playerControl.AnimDroneBody.SetBool("Move", false);
    }

    public void Move()
    {
        _playerControl.AnimDroneBody.SetBool("Move", true);
    }
}
