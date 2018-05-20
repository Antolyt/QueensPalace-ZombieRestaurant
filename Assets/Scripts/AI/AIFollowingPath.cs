using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollowingPath : BaseAI
{

    public WayPoint TargetPoint;

    Animator _animator;

    protected override void Start()
    {
        base.Start();

        _animator = GetComponent<Animator>();

        if (TargetPoint != null)
        {
            MovePosition = TargetPoint.transform.position;
        }

        _animator.SetBool("Walking", true);
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
