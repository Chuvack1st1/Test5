using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    private Slider slider;
    private void OnEnable()
    {
        Boss.OnBossHealthChanged += SetNewHealthValue;
        slider = GetComponent<Slider>();
    }
    private void SetNewHealthValue(Boss boss)
    {
        slider.value = (float)boss.BossHealth / (float)boss.MAXBOSSHP;
    }

    private void OnDestroy()
    {
        Boss.OnBossHealthChanged -= SetNewHealthValue;
    }
}
