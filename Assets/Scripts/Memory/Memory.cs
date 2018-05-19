using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour {

    private Dictionary<Type, WeaponAttribute> _weaponDictionary = new Dictionary<Type, WeaponAttribute>();
    private Dictionary<Type, BulletAttribute> _bulletDictionary = new Dictionary<Type, BulletAttribute>();

    // Use this for initialization
    void Awake () {

        _weaponDictionary.Set(typeof(Pistol), new WeaponAttribute
        {
            ReloadTime = 1f,
            Ammo = 8,
            MaxAmmo = 8,
            ShootDelay = 0.3f,
            Bullet = typeof(SimpleBullet),
            GameObject = (GameObject)Resources.Load("Bullets/SimpleBullet"),
            SprayAngle = 10,
            AmountShootBullets = 1,
            Force = 1000
        }).Set(typeof(MachineGun), new WeaponAttribute
        {
            ReloadTime = 4f,
            Ammo = 30,
            MaxAmmo = 30,
            ShootDelay = 0.05f,
            Bullet = typeof(SimpleBullet),
            GameObject = (GameObject)Resources.Load("Bullets/SimpleBullet"),
            AmountShootBullets = 1,
            SprayAngle = 5,
            Force = 400
        }).Set(typeof(Shotgun), new WeaponAttribute
        {
            ReloadTime = 6f,
            Ammo = 32,
            MaxAmmo = 32,
            ShootDelay = 0.4f,
            Bullet = typeof(ShotgunBullet),
            GameObject = (GameObject)Resources.Load("Bullets/SimpleBullet"),
            AmountShootBullets = 8,
            SprayAngle = 15,
            Force = 200
        });

        _bulletDictionary.Set(typeof(SimpleBullet), new BulletAttribute
        {
            Damage = 1f,
            Speed = 1000f,
            Lifetime = 3f
        }).Set(typeof(ShotgunBullet), new BulletAttribute
        {
            Damage = 2f,
            Speed = 2000f,
            Lifetime = 0.15f
        });
    }

    public void SetAttribute(Weapon obj)
    {
        if(_weaponDictionary.ContainsKey(obj.GetType()))
        {
            obj.Attr =  (WeaponAttribute)_weaponDictionary[obj.GetType()].Clone();
        }
    }

    public void SetAttribute(Bullet obj)
    {
        if (_bulletDictionary.ContainsKey(obj.GetType()))
        {
            obj.Attr = (BulletAttribute)_bulletDictionary[obj.GetType()].Clone();
        }
    }
}
