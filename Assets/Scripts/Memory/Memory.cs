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
            Bullet = typeof(SimpleBullet)
        }).Set(typeof(MachineGun), new WeaponAttribute
        {
            ReloadTime = 4f,
            Ammo = 30,
            MaxAmmo = 30,
            ShootDelay = 0.05f,
            Bullet = typeof(SimpleBullet)
        });

        _bulletDictionary.Set(typeof(SimpleBullet), new BulletAttribute
        {
            Damage = 1f,
            Speed = 0.2f,
            Lifetime = 3f
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
