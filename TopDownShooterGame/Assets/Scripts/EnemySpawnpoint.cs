using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnpoint : MonoBehaviour
{
    [SerializeField] private float spawnDelay = 2.0f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject spawningEffectPrefab;

    public void StartSpawning()
    {
        StartCoroutine(PerformEnemySpawn());
    }

    IEnumerator PerformEnemySpawn()
    {
        GameObject spawningEffect = Instantiate(spawningEffectPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnDelay);
        Destroy(spawningEffect);
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
