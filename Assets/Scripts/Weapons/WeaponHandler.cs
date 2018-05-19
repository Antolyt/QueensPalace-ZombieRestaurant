using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class WeaponHandler : MonoBehaviour
{

    [SerializeField]
    private List<Weapon> _weapons;

    [SerializeField]
    PlayerMovement _input;

    private Animator _animator;
    private Weapon _currWeapon;
    private int _weaponIndex = 0;

    public Weapon Weapon
    {
        get { return _currWeapon; }
    }

    // Use this for initialization
    void Start()
    {
        _currWeapon = _weapons[0];
        _currWeapon.enabled = true;
        _animator = GetComponent<Animator>();
    }

    private void OnValidate()
    {
        _input = GetComponent<PlayerMovement>();
        _weapons.Clear();
        _weapons.AddRange(GetComponentsInChildren<Weapon>());
        foreach (Weapon w in _weapons)
            w.OnShoot += ShootAnim;
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.GetButtonDown("R1"))
        {
            _currWeapon = NextWeapon();
        }
        else if (_input.GetButtonDown("L1"))
        {
            _currWeapon = PrevWeapon();
        }

        if (_animator != null)
            _animator.SetBool("Shoot", false);
    }

    private void ShootAnim(Weapon weap)
    {
        if (_animator != null)
            _animator.SetBool("Shoot", true);
    }

    private Weapon PrevWeapon()
    {
        _currWeapon.enabled = false;
        _weaponIndex--;
        if (_weaponIndex < 0)
            _weaponIndex = _weapons.Count - 1;
        _weapons[_weaponIndex].enabled = true;
        return _weapons[_weaponIndex];
    }

    private Weapon NextWeapon()
    {
        _currWeapon.enabled = false;
        _weaponIndex++;
        if (_weaponIndex == _weapons.Count)
            _weaponIndex = 0;
        _weapons[_weaponIndex].enabled = true;
        return _weapons[_weaponIndex];
    }
}
