using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public float EnemyShootDelay;

    public static UnityAction<Enemy> EnemyDieEvent;

    private List<Enemy> enemies = new();

    private Coroutine coroutine; 

    private void OnEnable()
    {
        EnemyDieEvent += RemoveEnemyFronList;

        for (int i = 0; i < transform.childCount; i++)
        {
            enemies.Add(transform.GetChild(i).GetComponent<Enemy>());
        }
        coroutine = StartCoroutine(EnemyShooting());
    }

    private void RemoveEnemyFronList(Enemy enemy)
    {
        enemies.Remove(enemy);
    }

    private IEnumerator EnemyShooting()
    {
        while (true)
        {
            if(enemies.Count >= 1)
                enemies[Random.Range(0, enemies.Count)].Shoot();

            yield return new WaitForSeconds(EnemyShootDelay);
        }        
    }

    private void OnDisable()
    {
        if(coroutine != null)
            StopCoroutine(coroutine);
    }
}
