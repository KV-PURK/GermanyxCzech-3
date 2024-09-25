using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeSelect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI upgradeNameText;
    [SerializeField] private TextMeshProUGUI upgradeDescriptionText;
    [SerializeField] private Image upgradeIcon;
    [SerializeField] private Color rareUpgradeColor;

    private PlayerUpgrade playerUpgrade;

    public void Setup(PlayerUpgrade upgrade)
    {
        playerUpgrade = upgrade;
        upgradeNameText.text = upgrade.upgradeName;
        upgradeDescriptionText.text = upgrade.upgradeDescription;
        upgradeIcon.sprite = upgrade.upgradeIcon;
        if (upgrade.isRare)
        {
            upgradeIcon.color = rareUpgradeColor;
        }
    }

    public void OnSelect()
    {
        playerUpgrade.ApplyUpgrade();

        UpgradeManager.Singleton.EndUpgradeSelection();
    }
}
