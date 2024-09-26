using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    [SerializeField] private Transform enemySpawnsHolder;
    private List<GameObject> doors;

    private int enemyCount = 0;

    private UnityEvent playerEnterRoomEvent;

    private List<GameObject> enemies;

    private bool spawned = false;

    private void Start()
    {
        doors = new List<GameObject>();
        enemies = new List<GameObject>();
        enemyCount = 0;
        InitDoors();
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

    private void InitDoors()
    {
        foreach (Transform t in transform.root.Find("Doors"))
        {
            doors.Add(t.gameObject);
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
        bool spawned = false;
        foreach (Transform spawn in enemySpawnsHolder)
        {
            EnemySpawnpoint enemySpawn = spawn.GetComponent<EnemySpawnpoint>();

            if (enemySpawn != null)
            {
                enemySpawn.StartSpawning();
                spawned = true;
            }
        }
        if (spawned)
            ToggleDoors(true);
    }

    private void ToggleDoors(bool toggle)
    {
        doors[0].transform.parent.gameObject.SetActive(toggle);
        foreach (GameObject door in doors)
        {
            door.SetActive(toggle);
        }

        if (toggle)
        {
            CameraShake.Singleton.ShakeCamera(0.5f, 4.0f);
        }
    }
}
