using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatUI : MonoBehaviour
{
    private Transform HealthPanel;
    private Transform ArmorPanel;

    private void OnEnable()
    {
        PlayerStats.ArmorChangedEvent += OnArmorChanged;
        PlayerStats.HealthChangedEvent += OnHealthChenged;

        HealthPanel = transform.GetChild(0);
        ArmorPanel = transform.GetChild(1);
    }

    private void Start()
    {
        //Init();
    }
    private void Init()
    {
        for (int i = 0; i < HealthPanel.childCount; i++)
        {
            HealthPanel.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0;i < ArmorPanel.childCount; i++)
        {
            ArmorPanel.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void OnHealthChenged(int newValue)
    {
        for (int i = 0; i < HealthPanel.childCount; i++)
        {
            if(i < newValue)
                HealthPanel.GetChild(i).gameObject.SetActive(true);
            else
                HealthPanel.GetChild(i).gameObject.SetActive(false);
        }
    }
    private void OnArmorChanged(int newValue)
    {
        for (int i = 0; i < ArmorPanel.childCount; i++)
        {
            if (i < newValue)
                ArmorPanel.GetChild(i).gameObject.SetActive(true);
            else
                ArmorPanel.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        PlayerStats.ArmorChangedEvent -= OnArmorChanged;
        PlayerStats.HealthChangedEvent -= OnHealthChenged;
    }

}
