using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : MonoBehaviour
{

    public EntityAttribute Attr;

    Rigidbody _rgdb;
    Vector3 _movePosition;

    protected virtual void Start()
    {
        _rgdb = GetComponent<Rigidbody>();
        Force = Attr.Speed;
    }

    public virtual float Force
    {
        get;
        set;
    }

    public virtual Vector3 MovePosition
    {
        get { return _movePosition; }
        set { _movePosition = value; }
    }

    protected virtual void Update()
    {
        Vector3 dir = _movePosition - transform.position;
        dir.Normalize();
        if (!MovePosition.Equals(Vector3.zero) && !dir.Equals(Vector3.zero))
        {
            transform.rotation = Quaternion.LookRotation(dir);
            transform.Rotate(new Vector3(0, 90, 0));
            _rgdb.AddForce(dir * Force);
        }



    }

}
