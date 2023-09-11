using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablerBossHealthBar : MonoBehaviour
{
    private void OnEnable()
    {
        LevelChankSpawner.OnBossSpawned += EnableBossHealthBar;
        Boss.OnBossDeath += DisenableBossHealthBar;
    }
    private void EnableBossHealthBar(Boss boss)
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    private void DisenableBossHealthBar(Boss boss)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        LevelChankSpawner.OnBossSpawned -= EnableBossHealthBar;
        Boss.OnBossDeath -= DisenableBossHealthBar;
    }
}
