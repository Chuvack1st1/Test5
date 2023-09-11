using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemsManager : MonoBehaviour
{
    public static ShopItemsManager Instance;

    public Transform HealthSlots;
    public Transform ArmorSlots;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this;
    }

    public Equipment GetEquipedArmorEquipment()
    {
        for (int i = 0; i < ArmorSlots.childCount; i++)
        {
            if (ArmorSlots.GetChild(i).GetComponent<EquipmentData>().equipment.isEquiped == true)
                return ArmorSlots.GetChild(i).GetComponent<EquipmentData>().equipment;
        }
        return ArmorSlots.GetChild(0).GetComponent<EquipmentData>().equipment;
    }

    public Equipment GetEquipedHealthEquipment()
    {
        for (int i = 0; i < HealthSlots.childCount; i++)
        {
            if (HealthSlots.GetChild(i).GetComponent<EquipmentData>().equipment.isEquiped == true)
                return HealthSlots.GetChild(i).GetComponent<EquipmentData>().equipment;
        }
        return  HealthSlots.GetChild(0).GetComponent<EquipmentData>().equipment; ;
    }
}
