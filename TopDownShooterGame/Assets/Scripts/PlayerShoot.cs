using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private float shootDelay = 0.5f;

    [Header("References")]
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;

    private float sinceShot;


    void Update()
    {
        sinceShot += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (sinceShot < shootDelay) return;


        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation).GetComponent<Bullet>();

        sinceShot = 0.0f;
    }
}
