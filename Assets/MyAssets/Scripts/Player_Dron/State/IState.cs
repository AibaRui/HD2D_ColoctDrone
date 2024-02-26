using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IState
{
    public abstract void Enter();
    public abstract void Update();

    public abstract void LateUpdate();

    public abstract void FixedUpdate();

    public abstract void Exit();
}