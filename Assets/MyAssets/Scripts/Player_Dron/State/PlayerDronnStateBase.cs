using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public abstract class PlayerDronnStateBase : IState
{
    [NonSerialized]
    protected PlayerDronnStateMachine _stateMachine = null;

    /// <summary>StateMacine‚ğƒZƒbƒg‚·‚éŠÖ”</summary>
    /// <param name="stateMachine"></param>
    public void Init(PlayerDronnStateMachine stateMachine)
    {
        _stateMachine = stateMachine;

    }



    public abstract void Enter();
    public abstract void Exit();
    public abstract void FixedUpdate();
    public abstract void Update();

    public abstract void LateUpdate();

}