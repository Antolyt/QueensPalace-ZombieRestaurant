using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttribute : ICloneable
{
    public float Health;
    public float Speed;
    public float Range;
    public float Damage;
    public float AttackSpeed;
    public float ViewingDistance;
    public float DistToWaypoint;
    public Type AIScript;
    public Type AttackScript;

    public object Clone()
    {
        return new EntityAttribute
        {
            Health = Health,
            Speed = Speed,
            Range = Range,
            Damage = Damage,
            AttackSpeed = AttackSpeed,
            AIScript = AIScript,
            ViewingDistance = ViewingDistance,
            DistToWaypoint = DistToWaypoint,
            AttackScript = AttackScript
        };
    }

    public void Attack(float other)
    {
        Health -= other;
    }
}
