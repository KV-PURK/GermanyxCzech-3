using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePickup : MonoBehaviour
{
    [SerializeField] private int optionsAmount = 2;
    [SerializeField] private GameObject pickupEffectPrefab;
    [SerializeField] private bool includeRare;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        UpgradeManager.Singleton.TriggerUpgradeSelection(optionsAmount, includeRare);
        if (pickupEffectPrefab != null)
            Instantiate(pickupEffectPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
