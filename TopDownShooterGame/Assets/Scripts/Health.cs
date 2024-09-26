using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Health stuff")]
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;

    [Header("Effects")]
    [SerializeField] private GameObject killEffect;

    [Header("Events")]
    public UnityEvent<int, int, int> damagedEvent;
    public UnityEvent deathEvent;

    public void Damage(int amount)
    {
        health -= amount;

        damagedEvent?.Invoke(amount, health, maxHealth);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        health += amount;

        damagedEvent?.Invoke(-amount, health, maxHealth);

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Die()
    {
        if (killEffect != null)
            Instantiate(killEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        deathEvent?.Invoke();
    }
}