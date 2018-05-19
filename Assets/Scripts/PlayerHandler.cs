using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : Entity {

    protected override void Update()
    {
        if (Attr.Health <= 0)
        {
            transform.position = new Vector3(0, -1.5f, 0);
            Attr.Health = 100;
        }
    }
}
