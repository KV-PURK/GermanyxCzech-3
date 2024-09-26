using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private float shootDelay = 0.5f;
    [SerializeField] private float multiShotDelay = 0.2f;

    [Header("References")]
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;

    private float sinceShot;


    void Update()
    {
        sinceShot += Time.deltaTime;

        if (Input.GetMouseButton(0) && !PauseManager.Singleton.IsPaused && sinceShot > shootDelay)
        {
            Shoot();
        }
    }

    void Shoot(bool useMultishot = true)
    {
        Bullet bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation).GetComponent<Bullet>();
        bullet.maxBounces = PlayerStats.Singleton.bulletBounces;
        bullet.damage = PlayerStats.Singleton.bulletDamage;
        bullet.speed = PlayerStats.Singleton.bulletSpeed;

        bullet.transform.localScale = 0.4f * PlayerStats.Singleton.bulletScale * Vector3.one;

        if (useMultishot)
        {
            int shots = ConvertMultishot();
            StartCoroutine(PerformMultishot(shots));
        }

        sinceShot = 0.0f;

        CameraShake.Singleton.ShakeCamera(0.15f, 1.5f);
    }

    IEnumerator PerformMultishot(int shots)
    {
        while (shots > 0)
        {
            yield return new WaitForSeconds(multiShotDelay);
            Shoot(false);
            shots--;
        }
    }

    private int ConvertMultishot()
    {
        int shots = 0;
        float currentChance = PlayerStats.Singleton.multishot;
        while (currentChance > 0)
        {
            if (Random.Range(0, 101) <= currentChance * 100)
            {
                shots++;
            }
            currentChance -= 1;
        }

        return shots;
    }
}
