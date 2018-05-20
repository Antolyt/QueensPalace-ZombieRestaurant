using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanHanAPI : MonoBehaviour {

    public WeaponDis weapon;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start () {
		
	}

    public void SetWeaponDis(string name, WeaponAttribute wa)
    {
        weapon.name = name;
        weapon.ReloadTime = wa.ReloadTime;
        weapon.ShootDelay = wa.ShootDelay;
        weapon.Ammo = wa.Ammo;
        weapon.MaxAmmo = wa.MaxAmmo;
        weapon.SprayAngle = wa.SprayAngle;
        weapon.AmountShootBullets = wa.AmountShootBullets;
        weapon.Force = wa.Force;
        weapon.Damage = wa.Damage;
    }
}

[Serializable]
public struct WeaponDis
{
    public string name;
    public float ReloadTime;
    public float ShootDelay;
    public int Ammo;
    public int MaxAmmo;
    public float SprayAngle;
    public int AmountShootBullets;
    public float Force;
    public float Damage;
}
