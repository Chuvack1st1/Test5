using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpenButton : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

    public void OpenMenuPanel()
    {
        menuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
