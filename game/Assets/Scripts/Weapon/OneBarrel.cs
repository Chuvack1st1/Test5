using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBarrel : Weapon
{
    public override void Shoot()
    {
        base.Shoot();
        Debug.Log(gameObject + " has shooted");
    }
}
