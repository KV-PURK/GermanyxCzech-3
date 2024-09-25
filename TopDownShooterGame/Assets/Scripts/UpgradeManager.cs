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

    }

    public void TriggerUpgradeSelection(int upgradeCount, bool includeRare)
    {
        List<PlayerUpgrade> randomUpgrades = GetRandomUpgrades(upgradeCount, includeRare);

        foreach (PlayerUpgrade upgrade in randomUpgrades)
        {
            UIManager.Singleton.SpawnUpgradeUI(upgrade);
        }

        UIManager.Singleton.ShowUpgradeSelectUI();

        if (!PauseManager.Singleton.IsPaused)
        {
            PauseManager.Singleton.ToggleGamePause();
        }
    }

    public void EndUpgradeSelection()
    {
        if (PauseManager.Singleton.IsPaused)
        {
            PauseManager.Singleton.ToggleGamePause();
        }
        UIManager.Singleton.HideUpgradeSelectUI();
    }

    private List<PlayerUpgrade> GetRandomUpgrades(int amount, bool includeRare)
    {
        if (amount > upgrades.Count) amount = upgrades.Count; // So we don't accidentally end up in an infinte loop

        List<PlayerUpgrade> randoms = new List<PlayerUpgrade>();
        for (int i = 0; i < amount; i++)
        {
            PlayerUpgrade upgrade = upgrades[Random.Range(0, upgrades.Count)];

            if (randoms.Contains(upgrade) || (!includeRare && upgrade.isRare))
            {
                i--;
                continue;
            }
            randoms.Add(upgrade);
        }

        return randoms;
    }
}
