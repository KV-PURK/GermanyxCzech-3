using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    [SerializeField] private Transform enemySpawnsHolder;
    [SerializeField] private List<GameObject> doors;

    private int enemyCount = 0;

    private UnityEvent playerEnterRoomEvent;

    private List<GameObject> enemies;

    private bool spawned = false;

    private void Awake()
    {
        enemies = new List<GameObject>();
        enemyCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !spawned)
        {
            OnPlayerEnterRoom();
            playerEnterRoomEvent?.Invoke();
            spawned = true;
        }
        if (collision.CompareTag("Enemy") && !enemies.Contains(collision.gameObject))
        {
            enemies.Add(collision.gameObject);
            enemyCount++;

            Health health = collision.GetComponent<Health>();
            if (health != null)
            {
                health.deathEvent.AddListener(new UnityAction(OnEnemyDeath));
            }
        }
    }

    public void OnEnemyDeath()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            ToggleDoors(false);
        }
    }

    private void OnPlayerEnterRoom()
    {
        foreach (Transform spawn in enemySpawnsHolder)
        {
            EnemySpawnpoint enemySpawn = spawn.GetComponent<EnemySpawnpoint>();

            if (enemySpawn != null)
            {
                enemySpawn.StartSpawning();
            }
        }

        ToggleDoors(true);
    }

    private void ToggleDoors(bool toggle)
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(toggle);
        }
    }
}
