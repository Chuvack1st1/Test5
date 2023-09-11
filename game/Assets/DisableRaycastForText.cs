using UnityEngine;
using TMPro;

public class DisableRaycastForText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        // Перевірка, чи вказаний компонент TextMeshProUGUI
        if (textMeshPro == null)
        {
            Debug.LogWarning("TextMeshProUGUI component not assigned!");
            return;
        }

        // Вимкнення операції RayCastTargeting
        textMeshPro.raycastTarget = false;
    }
}