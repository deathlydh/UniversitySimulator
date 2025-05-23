using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance;

    [SerializeField] private int startMoney = 10000;
    private int currentMoney;

    [System.Serializable]
    public class MoneyUpdateEvent : UnityEvent<int> { }
    public MoneyUpdateEvent OnMoneyUpdated = new MoneyUpdateEvent();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        currentMoney = startMoney;
    }

    public bool CanAfford(int amount) => currentMoney >= amount;

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyDisplay();
    }

    public void SpendMoney(int amount)
    {
        if (CanAfford(amount))
        {
            currentMoney -= amount;
            UpdateMoneyDisplay();
        }
    }

    public void UpdateMoneyDisplay()
    {
        OnMoneyUpdated.Invoke(currentMoney);
    }
}
