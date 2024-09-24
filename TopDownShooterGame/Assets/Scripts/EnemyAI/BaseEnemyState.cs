using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseEnemyState
{
    protected EnemyStateMachine stateMachine;

    public BaseEnemyState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public abstract void OnEnterState();
    public abstract void OnExitState();
    public abstract void OnUpdate();
    public abstract void OnFixedUpdate();
}
