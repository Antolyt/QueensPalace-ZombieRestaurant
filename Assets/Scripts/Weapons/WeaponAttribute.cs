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
    public GameObject GameObject;
    public float SprayAngle;
    public int AmountShootBullets;
    public float Force;
    public float Damage;

    public object Clone()
    {
        return new WeaponAttribute
        {
            ReloadTime = ReloadTime,
            ShootDelay = ShootDelay,
            Ammo = Ammo,
            MaxAmmo = MaxAmmo,
            Bullet = Bullet,
            GameObject = GameObject,
            SprayAngle = SprayAngle,
            AmountShootBullets = AmountShootBullets,
            Force = Force,
            Damage = Damage
        };
    }
}
