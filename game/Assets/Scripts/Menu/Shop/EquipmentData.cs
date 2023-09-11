using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentData : MonoBehaviour
{
    public Equipment equipment;

    public Button buyButton;
    public Button equipButton;

    private void OnEnable()
    {
        equipButton = transform.GetChild(0).GetChild(3).GetComponent<Button>();
        buyButton = transform.GetChild(0).GetChild(2).GetComponent<Button>();

        equipment.Name = transform.name;
        SaveLoadDataService.SaveDataEvent += equipment.Save;
        SaveLoadDataService.LoadDataEvent += equipment.Load;


        equipment.UpdateEquipedStateEvent += ChangeUIEpquiping;
        equipment.UpdateBuyedStateEvent += ChangeUIBuying;
    }

    public void OnArmorEquiping()
    {
        if (!equipment.isEquiped)
            if (equipment.IsBuyed)
            {
                ShopUI.OnArmorItemEquiped.Invoke(equipment);
            }
            else
                Debug.Log("you want to equipe a non buyed item");

    }
    public void OnHealthEquiping()
    {
        if (!equipment.isEquiped)
            if (equipment.IsBuyed)
                ShopUI.OnHealthItemEquiped.Invoke(equipment);
            else
                Debug.Log("you want to equipe a non buyed item");

    }
    public void OnBuying()
    {
        ShopUI.OnItemBuyed.Invoke(equipment);
    }

    private void ChangeUIEpquiping(bool isEquipped)
    {   
        if(equipButton != null)
            equipButton.interactable = !isEquipped;
    }
    private void ChangeUIBuying(bool isEquipped)
    {
        if (buyButton != null)
            buyButton.interactable = !isEquipped;
    }

    private void OnDestroy()
    {
        equipment.UpdateEquipedStateEvent -= ChangeUIEpquiping;
        equipment.UpdateBuyedStateEvent -= ChangeUIBuying;

        SaveLoadDataService.LoadDataEvent -= equipment.Load;
        SaveLoadDataService.SaveDataEvent -= equipment.Save;
    }
}
