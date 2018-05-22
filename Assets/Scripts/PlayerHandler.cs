using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : Entity {

    public Transform _respawnLocation;
    public Vector3 _altRespawnLocation;

    protected override void Update()
    {
        if (Attr.Health <= 0)
        {
            transform.position = _respawnLocation != null ? _respawnLocation.position : _altRespawnLocation;
            Attr.Health = 100;
        }
    }
}
