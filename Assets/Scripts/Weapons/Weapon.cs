using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField]
    protected Memory _memory;
    [SerializeField]
    protected PlayerMovement _input;
    protected Rigidbody _rgdb;

    public WeaponAttribute Attr = new WeaponAttribute();

    public delegate void DelOnShoot(Weapon weapon);
    public DelOnShoot OnShoot;

    private float timer = 0;

    public HanHanAPI hanHanApi;

    protected virtual void Start () {
        _input = GetComponentInParent<PlayerMovement>();
        _memory = GameObject.FindGameObjectWithTag("Memory").GetComponent<Memory>();
        _rgdb = GetComponentInParent<Rigidbody>();
        OnShoot += ShootBullet;

        if (_input == null)
        {
            Debug.LogWarning("Input Not Found " + this);
            enabled = false;
        }

        if(_memory == null)
        {
            Debug.LogWarning("Memory not found " + this);
            enabled = false;
        }
        else
        {
            _memory.SetAttribute(this);
        }
	}

    protected virtual void ShootBullet(Weapon weapon)
    {
        GameObject spawn = Instantiate(weapon.Attr.GameObject);
        spawn.transform.position = weapon.transform.position;

        Bullet bullet = (Bullet)spawn.AddComponent(weapon.Attr.Bullet);
        bullet.Dir = _input.GetShootDir();

        bullet.Dir = Quaternion.Euler(0, Random.Range(-Attr.SprayAngle / 2, Attr.SprayAngle / 2), 0) * bullet.Dir;

        _rgdb.AddForce(bullet.Dir * -1 * Attr.Force);
    }

    // Update is called once per frame
    protected virtual void Update () {

        timer += Time.deltaTime;

        if(_input.GetAxisDown("R2") && timer >= Attr.ShootDelay && Attr.Ammo > 0)
        {

            timer %= Attr.ShootDelay;

            if(OnShoot != null)
                OnShoot(this);

            Attr.Ammo -= Attr.AmountShootBullets;
        }
        else if(Attr.Ammo == 0 && timer >= Attr.ReloadTime)
        {
            timer %= Attr.ReloadTime;

            Attr.Ammo = Attr.MaxAmmo;
        }

        hanHanApi.SetWeaponDis(this.GetType().ToString(), Attr);
    }
}
