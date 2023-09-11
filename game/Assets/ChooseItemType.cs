using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseItemType : MonoBehaviour
{
    public List<GameObject> panels = new();

    private GameObject currentPanel;

    public Transform HealthSlots;
    public Transform ArmorSlots;

    private void Start()
    {
        Init();
    }
    private void Init()
    {
        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }
        OpenPanel(0);
    }

    public void OpenPanel(int number)
    {
        if(currentPanel != null)
            currentPanel.SetActive(false);

        currentPanel = panels[number];
        currentPanel.SetActive(true);
    }
    
}
