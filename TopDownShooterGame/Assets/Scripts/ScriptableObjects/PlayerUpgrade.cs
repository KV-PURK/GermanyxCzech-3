using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUpgrade", menuName = "Upgrade")]
public class PlayerUpgrade : ScriptableObject
{
    public string upgradeName;
    public string upgradeDescription;
    public Sprite upgradeIcon;

    public int bulletDamage;
    public int bulletBounces;
    public float movementSpeed;
    public float shootDelay;

    public void ApplyUpgrade()
    {
        PlayerStats.Singleton.bulletDamage += bulletDamage;
        PlayerStats.Singleton.bulletBounces += bulletBounces;
        PlayerStats.Singleton.movementSpeed += movementSpeed;
        PlayerStats.Singleton.shootDelay += shootDelay;
    }
}
