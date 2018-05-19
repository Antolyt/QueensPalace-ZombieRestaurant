using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyZombie : Entity {

    public WayPoint Target;

    protected override void Start()
    {
        base.Start();

        AIFollowingPath ai = GetComponent<AIFollowingPath>();
        ai.TargetPoint = Target;
    }

}
