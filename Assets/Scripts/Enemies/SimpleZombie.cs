using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleZombie : Entity
{

    public GameObject AudioOnDead;

    protected override void Update()
    {
        if (Attr.Health <= 0)
        {
            if (AudioOnDead != null)
                Instantiate(AudioOnDead);
        }

        base.Update();
    }

}
