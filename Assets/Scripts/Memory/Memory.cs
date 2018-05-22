using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour {
    public GameObject bullet;

    public FootTransformer[] bodyParts = null;
    private Dictionary<Type, WeaponAttribute> _weaponDictionary = new Dictionary<Type, WeaponAttribute>();
    private Dictionary<Type, BulletAttribute> _bulletDictionary = new Dictionary<Type, BulletAttribute>();
    private Dictionary<Type, EntityAttribute> _entityDictionary = new Dictionary<Type, EntityAttribute>();

    // Use this for initialization
    void Awake () {
        _weaponDictionary.Set(typeof(Pistol), new WeaponAttribute
        {
            ReloadTime = 1f,
            Ammo = 8,
            MaxAmmo = 8,
            ShootDelay = 0.3f,
            Bullet = typeof(SimpleBullet),
            GameObject = bullet,
            SprayAngle = 10,
            AmountShootBullets = 1,
            Force = 60
        }).Set(typeof(MachineGun), new WeaponAttribute
        {
            ReloadTime = 1f,
            Ammo = 30,
            MaxAmmo = 30,
            ShootDelay = 0.05f,
            Bullet = typeof(SimpleBullet),
            GameObject = bullet,
            AmountShootBullets = 1,
            SprayAngle = 5,
            Force = 20
        }).Set(typeof(Shotgun), new WeaponAttribute
        {
            ReloadTime = 2f,
            Ammo = 32,
            MaxAmmo = 32,
            ShootDelay = 0.4f,
            Bullet = typeof(ShotgunBullet),
            GameObject = bullet,
            AmountShootBullets = 8,
            SprayAngle = 15,
            Force = 10
        }).Set(typeof(AttackScript), new WeaponAttribute
        {
            ShootDelay = 0.3f,
            Force = 1000,
            Damage = 2
        });

        _bulletDictionary.Set(typeof(SimpleBullet), new BulletAttribute
        {
            Damage = 1f,
            Speed = 8000f,
            Lifetime = 3f
        }).Set(typeof(ShotgunBullet), new BulletAttribute
        {
            Damage = 2f,
            Speed = 5000f,
            Lifetime = 0.5f
        });

        _entityDictionary.Set(typeof(SimpleZombie), new EntityAttribute
        {
            AIScript = typeof(AINearestEntity),
            AttackSpeed = 0.4f,
            Damage = 1,
            Health = 10,
            MaxHealth = 10, 
            Range = 1,
            Speed = 100,
            ViewingDistance = 16,
            AttackScript = typeof(AttackScript)
        }).Set(typeof(FriendlyZombie), new EntityAttribute
        {
            AIScript = typeof(AIFollowingPath),
            AttackSpeed = 0.4f,
            Damage = 1,
            Health = 10,
            MaxHealth = 10,
            Range = 1,
            Speed = 80,
            ViewingDistance = 8,
            DistToWaypoint = 1
        }).Set(typeof(PlayerHandler), new EntityAttribute
        {
            Health = 100,
            MaxHealth = 100
        });
    }

    public void SetAttribute(CarrayObject obj)
    {
        obj.mets = bodyParts;
    }
    public void SetAttribute(Plate obj)
    {
        obj.mets = bodyParts;
    }
    public void SetAttribute(MeetProducer obj)
    {
        obj.meats = bodyParts;
    }
    public void SetAttribute(AttackScript obj)
    {
        if (_weaponDictionary.ContainsKey(obj.GetType()))
        {
            obj.Attr = (WeaponAttribute)_weaponDictionary[obj.GetType()].Clone();
        }
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

    public void SetAttribute(Entity obj)
    {
        if (_entityDictionary.ContainsKey(obj.GetType()))
        {
            obj.Attr = (EntityAttribute)_entityDictionary[obj.GetType()].Clone();
        }
    }
}
