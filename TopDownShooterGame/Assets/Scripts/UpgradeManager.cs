using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private static UpgradeManager _singleton;

    public static UpgradeManager Singleton
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
                Debug.LogWarning($"{nameof(UpgradeManager)} Instance already exists, destroying duplicate");
                Destroy(value);
            }
        }
    }

    public List<PlayerUpgrade> upgrades;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        TriggerUpgradeSelection();
    }

    public void TriggerUpgradeSelection()
    {
        List<PlayerUpgrade> randomUpgrades = GetRandomUpgrades(3);

        foreach (PlayerUpgrade upgrade in randomUpgrades)
        {
            UIManager.Singleton.SpawnUpgradeUI(upgrade);
        }

        UIManager.Singleton.ShowUpgradeSelectUI();

        Time.timeScale = 0.01f;
    }

    public void EndUpgradeSelection()
    {
        Time.timeScale = 1.0f;
        UIManager.Singleton.HideUpgradeSelectUI();
    }

    private List<PlayerUpgrade> GetRandomUpgrades(int amount)
    {
        List<PlayerUpgrade> randoms = new List<PlayerUpgrade>();
        for (int i = 0; i < amount; i++)
        {
            PlayerUpgrade upgrade = upgrades[Random.Range(0, upgrades.Count)];

            if (randoms.Contains(upgrade))
            {
                i--;
                continue;
            }
            randoms.Add(upgrade);
        }

        return randoms;
    }
}
