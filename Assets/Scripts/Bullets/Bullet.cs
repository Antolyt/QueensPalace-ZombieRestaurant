using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public BulletAttribute Attr = new BulletAttribute();
    public Vector3 Dir;

    Memory _memory;
    Rigidbody _rgdb;

    // Use this for initialization
    protected virtual void Start()
    {
        _memory = GameObject.FindGameObjectWithTag("Memory").GetComponent<Memory>();

        if (_memory == null)
        {
            Debug.LogWarning("Memory not found");
            enabled = false;
        }
        else
        {
            _memory.SetAttribute(this);
        }

        _rgdb = GetComponent<Rigidbody>();
        _rgdb.AddForce(Dir * Attr.Speed);
        transform.rotation = Quaternion.FromToRotation(Vector3.up, Dir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Entity entity = collision.gameObject.GetComponent<Entity>();
            entity.Attr.Attack(Attr.Damage);
            Destroy(gameObject);
        }
    }

    protected virtual void Update()
    {
        Attr.Lifetime -= Time.deltaTime;
        if (Attr.Lifetime <= 0)
            Destroy(gameObject);
    }

}
