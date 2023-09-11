using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseShopButton : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject openButton;

    public void CloseShop()
    {
        shopUI.SetActive(false);
        openButton.SetActive(true);
    }
}
