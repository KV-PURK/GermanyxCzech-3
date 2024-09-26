using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgrade", menuName = "Upgrade")]
public class PlayerUpgrade : ScriptableObject
{
    [Header("Visual")]
    public string upgradeName;
    public string upgradeDescription;
    public Sprite upgradeIcon;

    [Header("Stats")]
    public bool isRare;

    public int bulletDamage;
    public int bulletBounces;
    public float movementSpeed;
    public float shootDelay;
    public float bulletScale;
    public float bulletSpeed;
    public float multishotGain;

    public void ApplyUpgrade()
    {
        PlayerStats.Singleton.bulletDamage += bulletDamage;
        PlayerStats.Singleton.bulletBounces += bulletBounces;
        PlayerStats.Singleton.movementSpeed += movementSpeed;
        PlayerStats.Singleton.shootDelay += shootDelay;
        PlayerStats.Singleton.bulletScale += bulletScale;
        PlayerStats.Singleton.bulletSpeed += bulletSpeed;
        PlayerStats.Singleton.multishot += multishotGain;

        if (shootDelay < 0.1f)
        {
            shootDelay = 0.1f;
        }
    }
}
