using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingState : BaseEnemyState
{
    private float shootDelay = 1.0f;

    private Transform shootPoint;
    private Transform player;
    private GameObject bulletPrefab;

    private float sinceShot;


    public ShootingState(EnemyStateMachine stateMachine, Transform player, Transform shootPoint, GameObject bulletPrefab) : base(stateMachine)
    {
        this.player = player;
        this.shootPoint = shootPoint;
        this.bulletPrefab = bulletPrefab;
    }

    public override void OnEnterState()
    {
        sinceShot = 0.5f;
    }

    public override void OnExitState()
    {
        
    }

    public override void OnFixedUpdate()
    {

    }

    public override void OnUpdate()
    {
        stateMachine.LookAtPlayer();

        sinceShot += Time.deltaTime;

        if (Vector2.Distance(stateMachine.transform.position, player.position) > 9.0f)
        {
            stateMachine.SwitchToState(stateMachine.followState);
            return;
        }

        Shoot();
    }

    private void Shoot()
    {
        if (sinceShot < shootDelay) return;

        if (bulletPrefab != null)
        {
            StateMachine.Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        }

        sinceShot = 0.0f;
    }
}
