using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttribute : ICloneable {

    public float Speed;
    public float Damage;
    public float Lifetime;

    public object Clone()
    {
        return new BulletAttribute
        {
            Speed = Speed,
            Damage = Damage,
            Lifetime = Lifetime
        };
    }
}
