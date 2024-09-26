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

        if (Input.GetMouseButton(0) && !PauseManager.Singleton.IsPaused)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (sinceShot < shootDelay) return;


        Bullet bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation).GetComponent<Bullet>();
        bullet.maxBounces = PlayerStats.Singleton.bulletBounces;
        bullet.damage = PlayerStats.Singleton.bulletDamage;
        bullet.speed = PlayerStats.Singleton.bulletSpeed;

        bullet.transform.localScale = 0.4f * PlayerStats.Singleton.bulletScale * Vector3.one;


        sinceShot = 0.0f;

        CameraShake.Singleton.ShakeCamera(0.15f, 1.5f);
    }
}
