using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon {

    protected override void Start()
    {
        base.Start();
        OnShoot += ShootBullet;
    }


    protected override void ShootBullet(Weapon weapon)
    {
        for (int i = 0; i < Attr.AmountShootBullets; ++i)
        {
            GameObject spawn = Instantiate(weapon.Attr.GameObject);
            spawn.transform.position = weapon.transform.position;

            Bullet bullet = (Bullet)spawn.AddComponent(weapon.Attr.Bullet);
            bullet.Dir = _input.GetShootDir();

            bullet.Dir = Quaternion.Euler(0, Random.Range(-Attr.SprayAngle / 2, Attr.SprayAngle / 2), 0) * bullet.Dir;

            _rgdb.AddForce(bullet.Dir * -1 * Attr.Force);
        }
    }
}
