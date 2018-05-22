using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINearestEntity : BaseAI
{

    Animator _animator;

    protected override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
    }

    private GameObject GetTarget()
    {
        List<GameObject> objects = new List<GameObject>();
        objects.AddRange(GameObject.FindGameObjectsWithTag("Friendly"));
        objects.Add(GameObject.FindGameObjectWithTag("Player"));

        float dist = Attr.ViewingDistance;
        GameObject target = null;

        foreach (GameObject obj in objects)
        {
            if (obj == null)
                continue;

            float help = (obj.transform.position - transform.position).magnitude;
            if (help <= dist)
            {
                target = obj;
                dist = help;
            }
        }

        return target;
    }

    protected override void Update()
    {
        GameObject target = GetTarget();
        if (target != null)
        {
            MovePosition = target.transform.position;
            if (_animator != null)
                _animator.SetBool("Walking", true);
        }
        else
        {
            if (_animator != null)
                _animator.SetBool("Walking", false);
            MovePosition = Vector3.zero;
        }

        base.Update();
    }

}
