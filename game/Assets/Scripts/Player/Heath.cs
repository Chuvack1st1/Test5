using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Health : State
{
    public override int Count { 
        get => base.Count;
        set 
        {
            if (IsGameStoped.IsGameCountined)
            {
                if (value <= 0)
                {
                    PlayerManager.PlayerDieAction?.Invoke();
                }
            }
            base.Count = Mathf.Clamp(value, 0, 1000);
            PlayerStats.HealthChangedEvent?.Invoke(value);
        }
    }

}
