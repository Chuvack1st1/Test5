using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Transform[] _shotpoints;
    [SerializeField] private GameObject _bulletPrefab;


    public float ShootDelay = 1f;

    public float LiveTime = 0.5f;
    private void OnEnable()
    {
        MeaponManager.OnShoot += Shoot;
    }
    public virtual void Shoot()
    {
        if(_shotpoints.Length != 0)
            foreach (Transform t in _shotpoints)
            {
                var bulletPawn = Instantiate(_bulletPrefab, t.position, t.rotation);

                Destroy(bulletPawn, LiveTime);
            }
    }
    private void OnDisable()
    {
        MeaponManager.OnShoot -= Shoot;
    }
}
