using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Money
{
    public int _count;

    public int Count
    {
        get { return _count; }
        set
        {
            _count = (int)Mathf.Clamp(value, 0, Mathf.Infinity);
            MoneyCountChangedEvent.Invoke(_count);
        }
    }

    public static UnityAction<int> MoneyCountChangedEvent;

    public void Save()
    {
        PlayerPrefs.SetInt("Money", Count);
    }
    public void Load()
    {
        Count = PlayerPrefs.GetInt("Money", 0);
    }
}
