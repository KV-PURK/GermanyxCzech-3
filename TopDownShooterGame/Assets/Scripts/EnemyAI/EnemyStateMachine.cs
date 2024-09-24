using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;

    private BaseEnemyState currentState;

    public PlayerFollowState followState;
    public ShootingState shootingState;

    private Transform player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        followState = new PlayerFollowState(this, player);
        shootingState = new ShootingState(this, player, shootPoint, bulletPrefab);

        SwitchToState(followState);
    }

    private void Update()
    {
        currentState.OnUpdate();
    }

    private void FixedUpdate()
    {
        currentState.OnFixedUpdate();
    }

    public void SwitchToState(BaseEnemyState state)
    {
        currentState?.OnExitState();

        currentState = state;
        state.OnEnterState();
    }

    public void LookAtPlayer()
    {
        Vector2 diff = player.position - transform.position;

        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        transform.eulerAngles = new Vector3(0, 0, angle - 90.0f);
    }
}
