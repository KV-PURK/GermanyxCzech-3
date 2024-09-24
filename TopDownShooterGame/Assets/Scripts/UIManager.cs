using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _singleton;


    public static UIManager Singleton
    {
        get => _singleton;

        set
        {
            if (_singleton == null)
            {
                _singleton = value;
            }else
            {
                Debug.LogWarning($"{nameof(UIManager)} Instance already exists, destroying duplicate");
                Destroy(value);
            }
        }
    }

    [SerializeField] private Slider healthSlider;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void OnPlayerDamaged(int amount, int curHealth, int maxHealth)
    {
        healthSlider.value = (float)curHealth / maxHealth;
    }
}
