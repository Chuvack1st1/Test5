
using UnityEngine;

public class OpenShopButton : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;

    public void OpenShop()
    {
        shopUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
