using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenuButton : MonoBehaviour
{

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject openPanel;
    public void CloseMenuPanel()
    {
        menuPanel.SetActive(false);
        openPanel.SetActive(true);
    }
}
