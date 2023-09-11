using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private Armor currentArmorCount = new();
    [SerializeField] private Health currentHealthCount = new();
    [SerializeField] private Money currentMoney = new();

    [SerializeField] private Equipment currentArmorEquipment;
    [SerializeField] private Equipment currentHealthEquipment;

    public static UnityAction<int> HealthChangedEvent;
    public static UnityAction<int> ArmorChangedEvent;

    private void OnEnable()
    {
        ShopUI.OnArmorItemEquiped += EquipArmorItem;
        ShopUI.OnHealthItemEquiped += EquipHealthItem;
        ShopUI.OnItemBuyed += BuyItem;


        EnemyManager.EnemyDieEvent += GetpriceFromEnemyDeath;
        SaveLoadDataService.SaveDataEvent += currentMoney.Save;
        SaveLoadDataService.LoadDataEvent += currentMoney.Load;

        EntryPoint.InitEvent += InitStat;
    }

    public void TakeDamage()
    {
        if (currentArmorCount.Count > 0)
            currentArmorCount.Count--;
        else
            currentHealthCount.Count--;
    }

    public void Die()
    {
        currentHealthCount.Count = 0;
    }

    private void GetpriceFromEnemyDeath(Enemy enemy)
    {
        currentMoney.Count += enemy.diePrice;
    }

    private void InitStat()
    {
        currentArmorCount.Count = 1;
        currentHealthCount.Count = 1;
        EquipArmorItem(ShopItemsManager.Instance.GetEquipedArmorEquipment());
        EquipHealthItem(ShopItemsManager.Instance.GetEquipedHealthEquipment());
    }

    private void EquipArmorItem(Equipment newArmorEquipment)
    {
        if (currentArmorEquipment != null)
        {
            currentArmorCount.Count -= currentArmorEquipment.Stat.Count;
            currentArmorEquipment.IsEquiped = false;
        }

        if(newArmorEquipment != null)
        {
            currentArmorEquipment = newArmorEquipment;
            currentArmorEquipment.IsEquiped = true;
            currentArmorCount.Count += currentArmorEquipment.Stat.Count;
        }
    }
    private void EquipHealthItem(Equipment newHealthEquipment)
    {
        if(currentHealthEquipment != null)
        {
            currentHealthCount.Count -= currentHealthEquipment.Stat.Count;
            currentHealthEquipment.IsEquiped = false;
        }

        if (newHealthEquipment != null)
        {
            currentHealthEquipment = newHealthEquipment;
            currentHealthEquipment.IsEquiped = true;
            currentHealthCount.Count += currentHealthEquipment.Stat.Count;
        }
    }
    private void BuyItem(Equipment newEquipment)
    {
        if(!newEquipment.IsBuyed)
            if(currentMoney.Count - newEquipment.Cost >= 0)
            {
                currentMoney.Count -= newEquipment.Cost;
                newEquipment.IsBuyed = true;
                Debug.Log("u just buyed item");
            }
            else
            {
                newEquipment.IsBuyed = false;
                Debug.Log("u have no money");
            }
    }

    private void OnDisable()
    {
        ShopUI.OnArmorItemEquiped -= EquipArmorItem;
        ShopUI.OnHealthItemEquiped -= EquipHealthItem;
        ShopUI.OnItemBuyed -= BuyItem;

        SaveLoadDataService.SaveDataEvent -= currentMoney.Save;
        SaveLoadDataService.LoadDataEvent -= currentMoney.Load;

        EnemyManager.EnemyDieEvent -= GetpriceFromEnemyDeath;
    }
}
