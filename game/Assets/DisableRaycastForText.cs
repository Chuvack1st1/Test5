using UnityEngine;
using TMPro;

public class DisableRaycastForText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        // ��������, �� �������� ��������� TextMeshProUGUI
        if (textMeshPro == null)
        {
            Debug.LogWarning("TextMeshProUGUI component not assigned!");
            return;
        }

        // ��������� �������� RayCastTargeting
        textMeshPro.raycastTarget = false;
    }
}