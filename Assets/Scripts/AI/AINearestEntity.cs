using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINearestEntity : BaseAI {

    private GameObject GetTarget()
    {
        List<GameObject> objects = new List<GameObject>();
        objects.AddRange(GameObject.FindGameObjectsWithTag("Friendly"));
        objects.Add(GameObject.FindGameObjectWithTag("Player"));

        float dist = Attr.ViewingDistance;
        GameObject target = null;

        foreach(GameObject obj in objects)
        {
            if (obj == null)
                continue;
            
            float help = (obj.transform.position - transform.position).magnitude;
            if(help <= dist)
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
        if(target != null)
            MovePosition = target.transform.position;

        base.Update();
    }

}
