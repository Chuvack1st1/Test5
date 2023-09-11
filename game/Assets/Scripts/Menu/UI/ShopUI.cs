using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopUI : MonoBehaviour
{
    public static UnityAction<Equipment> OnArmorItemEquiped;
    public static UnityAction<Equipment> OnHealthItemEquiped;

    public static UnityAction<Equipment> OnItemBuyed;
}
