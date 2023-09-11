using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class Equipment
{
    public State Stat = new();

    public string Name;

    public bool isBuyed = false;
    public bool isEquiped = false;

    public int Cost;

    public UnityAction<bool> UpdateEquipedStateEvent;
    public UnityAction<bool> UpdateBuyedStateEvent;

    public bool IsBuyed { get => isBuyed; set { UpdateBuyedStateEvent?.Invoke(value); isBuyed = value; } }
    public bool IsEquiped { get => isEquiped; 
        set 
        {
            UpdateEquipedStateEvent?.Invoke(value);
            
            isEquiped = value;
        } 
    }
    public Equipment()
    {
        
    }
    public void Load()
    {
        int valueEquiped = PlayerPrefs.GetInt(Name + "valueEquiped", -1);
        if (valueEquiped == 0)
            IsEquiped = false;
        else if (valueEquiped == 1)
            IsEquiped = true;
        else
            throw new Exception();

        int valueBuyed = PlayerPrefs.GetInt(Name + "valueBuyed", -1);
        if (valueBuyed == 0)
            IsBuyed = false;
        else if (valueBuyed == 1)
            IsBuyed = true;
        else
            throw new Exception();
    }

    public void Save()
    {
        int valueEquiped;
        if (IsEquiped == false)
            valueEquiped = 0;
        else if (IsEquiped == true)
            valueEquiped = 1;
        else
            throw new Exception();
        PlayerPrefs.SetInt(Name + "valueEquiped", valueEquiped);

        int valueBuyed;
        if (IsBuyed == false)
            valueBuyed = 0;
        else if (IsBuyed == true)
            valueBuyed = 1;
        else
            throw new Exception();

        PlayerPrefs.SetInt(Name + "valueBuyed", valueBuyed);
    }
}

