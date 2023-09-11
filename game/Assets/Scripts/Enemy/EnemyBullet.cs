using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    void Update()
    {
        Move(-Vector3.forward, BulletSpeed);
    }
}
