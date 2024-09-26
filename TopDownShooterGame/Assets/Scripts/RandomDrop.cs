using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomDrop : MonoBehaviour
{
    [SerializeField] private List<Drop> possibleDrops;
    [SerializeField] private float dropRange = 0.2f;
    
    public void TriggerRandomDrop()
    {
        foreach (Drop drop in possibleDrops)
        {
            if (Random.Range(0, 101) <= drop.chance)
            {
                Vector2 dropPos = new Vector2(transform.position.x + Random.Range(-dropRange, dropRange), transform.position.y + Random.Range(-dropRange, dropRange));
                Instantiate(drop.dropPrefab, dropPos, Quaternion.identity);
            }
        }
    }
}

[Serializable]
public struct Drop
{
    public int chance;
    public GameObject dropPrefab;
}