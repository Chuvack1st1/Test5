using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;

    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private ParticleSystem _particleSystem;

    public float _liveTime;

    public int diePrice;

    private void OnEnable()
    {
        EnemyManager.EnemyDieEvent += OnEnemyDeath;
    }

    public void Shoot()
    {
        var bulletPawn = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);

        Bullet bullet = bulletPawn.GetComponent<EnemyBullet>();

        Destroy(bulletPawn, bullet.LiveTime);
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        enemy.transform.GetChild(0).gameObject.SetActive(false);

        enemy._particleSystem.Play();

        Destroy(enemy.gameObject, enemy._particleSystem.main.duration);
    }

    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponentInParent<Bullet>();
        if (bullet != null)
        {
            EnemyManager.EnemyDieEvent.Invoke(this);

            Destroy(bullet.gameObject);
        }
    }

    private void OnDisable()
    {
        EnemyManager.EnemyDieEvent -= OnEnemyDeath;
    }
}
