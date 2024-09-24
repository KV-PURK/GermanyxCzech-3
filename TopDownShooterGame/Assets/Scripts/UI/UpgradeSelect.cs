using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeSelect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI upgradeNameText;
    [SerializeField] private TextMeshProUGUI upgradeDescriptionText;

    private PlayerUpgrade playerUpgrade;

    public void Setup(PlayerUpgrade upgrade)
    {
        playerUpgrade = upgrade;
        upgradeNameText.text = upgrade.upgradeName;
        upgradeDescriptionText.text = upgrade.upgradeDescription;
    }

    public void OnSelect()
    {
        playerUpgrade.ApplyUpgrade();

        UpgradeManager.Singleton.EndUpgradeSelection();
    }
}
