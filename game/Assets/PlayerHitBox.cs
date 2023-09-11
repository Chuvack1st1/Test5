using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private PlayerStats playerStats;

    private void OnEnable()
    {
        playerStats = GetComponentInParent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyBullet bullet = other.gameObject.GetComponentInParent<EnemyBullet>();
        if (bullet != null)
        {
            Debug.Log("Player get damage by enemy bullet");
            playerStats.TakeDamage();
            Destroy(bullet.gameObject);
        }

        Enemy enemy = other.gameObject.GetComponentInParent<Enemy>();
        if (enemy != null)
        {
            EnemyManager.EnemyDieEvent.Invoke(enemy);
            Destroy(other.gameObject);
        }

        Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            Debug.Log("Player get damage by enemy obstacle");
            playerStats.Die();
        }
    }
}
