using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowingPlayer : BaseAI {

    GameObject _player;

    protected override void Start()
    {
        base.Start();

        _player = GameObject.FindGameObjectWithTag("Player");

        MovePosition = _player.transform.position;
    }

    protected override void Update()
    {
        float dist = (_player.transform.position - transform.position).magnitude;
        if (dist <= Attr.ViewingDistance)
        {
            MovePosition = _player.transform.position;
        }
        else
        {
            MovePosition = transform.position;
        }

        base.Update();
    }

}
