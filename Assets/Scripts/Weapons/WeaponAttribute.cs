using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttribute : ICloneable{

    public float ReloadTime;
    public float ShootDelay;
    public int Ammo;
    public int MaxAmmo;
    public Type Bullet;

    public object Clone()
    {
        return new WeaponAttribute
        {
            ReloadTime = ReloadTime,
            ShootDelay = ShootDelay,
            Ammo = Ammo,
            MaxAmmo = MaxAmmo,
            Bullet = Bullet
        };
    }
}
