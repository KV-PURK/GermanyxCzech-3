using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats _singleton;

    public static PlayerStats Singleton
    {
        get => _singleton;

        set
        {
            if (_singleton == null)
            {
                _singleton = value;
            }
            else
            {
                Debug.LogWarning($"{nameof(UIManager)} Instance already exists, destroying duplicate");
                Destroy(value);
            }
        }
    }

    public int bulletDamage = 10;
    public int bulletBounces = 2;
    public float movementSpeed = 10.0f;
    public float shootDelay = 0.75f;
    public float bulletScale = 1.0f;
    public float bulletSpeed = 10.0f;

    private void Awake()
    {
        Singleton = this;
    }
}
