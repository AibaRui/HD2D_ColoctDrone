using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DronnMoveState : PlayerDronnStateBase
{
    public override void Enter()
    {
        //速度制限の設定
        _stateMachine.PlayerController.PlayerDroneSpeedLimit.SetSpeed(DroneSpeedLimit.Move);

        _stateMachine.PlayerController.PlayerDroneAnimatorControl.Move();
    }

    public override void Exit()
    {

    }

    public override void FixedUpdate()
    {
        //移動
        _stateMachine.PlayerController.Move.Move();

        //速度制限
        _stateMachine.PlayerController.PlayerDroneSpeedLimit.LimitSpeed();

        //回転設定
        _stateMachine.PlayerController.Rotation.Rotation();
    }

    public override void LateUpdate()
    {

    }

    public override void Update()
    {
        var h = _stateMachine.PlayerController.InputManager.GetValue<float>(InputType.MoveHorizontal);
        var v = _stateMachine.PlayerController.InputManager.GetValue<float>(InputType.InputVertical);

        if (h == 0 && v == 0)
        {
            _stateMachine.TransitionTo(_stateMachine.StateIdle);
        }
    }
}
