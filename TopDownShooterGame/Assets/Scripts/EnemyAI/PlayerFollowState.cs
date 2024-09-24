using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowState : BaseEnemyState
{
    private Rigidbody2D rb;
    private Transform player;
    public PlayerFollowState(EnemyStateMachine stateMachine, Transform player) : base(stateMachine)
    {
        this.player = player;
    }

    public override void OnEnterState()
    {
        rb = stateMachine.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
    }

    public override void OnExitState()
    {
        
    }

    public override void OnFixedUpdate()
    {
        rb.velocity = Vector2.zero;

        if (Vector2.Distance(stateMachine.transform.position, player.position) < 7.0f)
        {
            stateMachine.SwitchToState(stateMachine.shootingState);
            return;
        }

        Vector2 forward = stateMachine.transform.up;
        rb.MovePosition(rb.position + forward * 7.0f * Time.deltaTime);
    }

    public override void OnUpdate()
    {
        stateMachine.LookAtPlayer();
    }
}
