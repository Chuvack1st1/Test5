using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Armor : State
{
    public override int Count { get => base.Count;
        set 
        {
            base.Count = value;
            PlayerStats.ArmorChangedEvent?.Invoke(base.Count);
        } 
    }
}
