using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public WeaponAttribute Attr;

    Animator _animCtrl;
    Memory _memory;
    Rigidbody _rgdb;
    double timer;

    // Use this for initialization
    void Start()
    {
        _memory = GameObject.FindGameObjectWithTag("Memory").GetComponent<Memory>();
        _rgdb = GetComponent<Rigidbody>();
        _animCtrl = GetComponent<Animator>();

        if (_memory == null)
        {
            Debug.LogWarning("Memory not found");
            enabled = false;
        }
        else
        {
            _memory.SetAttribute(this);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision)
    {
        Entity script = collision.gameObject.GetComponent<Entity>();
        if (script != null && timer >= Attr.ShootDelay && !collision.gameObject.CompareTag("Enemy"))
        {
            _animCtrl.SetBool("Attack", true);
            script.Attr.Attack(Attr.Damage);
            timer = 0;

            Rigidbody eRgdb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 dir = script.transform.position - transform.position;
            dir.Normalize();

            _rgdb.AddForce(dir * -1 * Attr.Force / 2);
            eRgdb.AddForce(dir * Attr.Force / 2);
        }
        else
            _animCtrl.SetBool("Attack", false);
    }
}
