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
    [SerializeField] private GameObject upgradeUIPrefab;
    [SerializeField] private Transform upgradeSelectUI;
    [SerializeField] private Transform upgradesHolder;

    private void Awake()
    {
        Singleton = this;
    }

    public void OnPlayerDamaged(int amount, int curHealth, int maxHealth)
    {
        healthSlider.value = (float)curHealth / maxHealth;
    }

    public void SpawnUpgradeUI(PlayerUpgrade playerUpgrade)
    {
        UpgradeSelect upgradeUI = Instantiate(upgradeUIPrefab, upgradesHolder.position, Quaternion.identity).GetComponent<UpgradeSelect>();
        upgradeUI.transform.SetParent(upgradesHolder);

        upgradeUI.Setup(playerUpgrade);
    }

    public void ShowUpgradeSelectUI()
    {
        upgradeSelectUI.gameObject.SetActive(true);
    }

    public void HideUpgradeSelectUI()
    {
        upgradeSelectUI.gameObject.SetActive(false);

        foreach (Transform child in upgradesHolder.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
