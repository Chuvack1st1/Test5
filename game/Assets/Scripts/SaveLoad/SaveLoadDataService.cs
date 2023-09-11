using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.Events;

public class SaveLoadDataService : MonoBehaviour
{
    public static UnityAction SaveDataEvent;
    public static UnityAction LoadDataEvent;

    private void OnEnable()
    {
        EntryPoint.LoadEvent += DoLoad;
    }

    public void DoSave()
    {
        SaveDataEvent?.Invoke();
    }

    public void DoLoad()
    {
        LoadDataEvent?.Invoke();
    }
    private void OnDisable()
    {
        EntryPoint.LoadEvent -= DoLoad;
    }
}
