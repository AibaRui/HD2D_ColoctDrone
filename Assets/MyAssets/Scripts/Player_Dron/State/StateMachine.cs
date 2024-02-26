using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class StateMachine
{
    [NonSerialized]
    private IState _currentState = default;
    public IState CurrentState => _currentState;

    /// <summary>IState(インターフェイス)型のUpdateを回す</summary>
    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

    public void LateUpdate()
    {
        if (CurrentState != null)
        {
            CurrentState.LateUpdate();
        }
    }

    public void FixedUpdate()
    {
        if (CurrentState != null)
        {
            CurrentState.FixedUpdate();
        }
    }

    public event Action<IState> OnStateChanged = default;

    // 最初のステートを設定する。
    protected void Initialize(IState startState)
    {
        StateInit();

        _currentState = startState;
        startState.Enter();

        // ステート変化時に実行するアクション。
        // 引数に最初のステートを渡す。
        OnStateChanged?.Invoke(startState);
    }

    // ステートの遷移処理。引数に「次のステートの参照」を受け取る。

    /// <summary>ステートを変更する関数</summary>
    /// <param name="nextState"></param>
    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();      // 現在ステートの終了処理。
        _currentState = nextState; // 現在のステートの変更処理。
        nextState.Enter();        // 変更された「新しい現在ステート」のEnter処理。

        // ステート変更時のアクションを実行する。
        // 引数に「新しい現在ステート」を渡す。
        OnStateChanged?.Invoke(nextState);
    }


    protected abstract void StateInit();
}