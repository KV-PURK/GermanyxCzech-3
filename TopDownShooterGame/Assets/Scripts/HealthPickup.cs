using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int amount = 15;
    [SerializeField] private GameObject pickupEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            health.Heal(amount);

            if (pickupEffect != null)
                Instantiate(pickupEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
