using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIEconomyDisplay : MonoBehaviour
{

    [Header("UI References")]
    [SerializeField] private TMP_Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        EconomyManager.Instance.OnMoneyUpdated.AddListener(UpdateMoney);
        EconomyManager.Instance.UpdateMoneyDisplay();
    }

    private void UpdateMoney(int amount)
    {
        moneyText.text = $"Budget: {amount}";
    }
}
