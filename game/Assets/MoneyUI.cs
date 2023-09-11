using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_TextMeshPro;

    private void OnEnable()
    {
        Money.MoneyCountChangedEvent += OnMoneycountChanged;
    }

    private void OnMoneycountChanged(int newValue)
    {
        m_TextMeshPro.text = "Money: " + newValue;
    }

    private void OnDisable()
    {
        Money.MoneyCountChangedEvent -= OnMoneycountChanged;
    }
}
