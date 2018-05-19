using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowingPath : BaseAI {

    public WayPoint TargetPoint;

    protected override void Start()
    {
        base.Start();

        if (TargetPoint != null)
        {
            MovePosition = TargetPoint.transform.position;
        }
    }

    protected override void Update()
    {
        base.Update();

        if (TargetPoint != null)
        {
            float dist = (TargetPoint.transform.position - transform.position).magnitude;

            if (dist <= Attr.DistToWaypoint)
            {
                TargetPoint = TargetPoint.Next;

                if (TargetPoint != null)
                    MovePosition = TargetPoint.transform.position;
                else
                    Destroy(gameObject);
            }
        }
    }
}
