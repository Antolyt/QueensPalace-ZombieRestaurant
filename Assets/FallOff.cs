using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOff : MonoBehaviour
{
    public List<GameObject> FallOfPart;
    public Transform Root;
    public int Amount;

    public SkinnedMeshRenderer Remove = null;

    EntityAttribute _attr;

    [Range(0, 1)]
    public float BreakTrigger;
    public float BreakForce;

    private void Start()
    {
        Entity e = GetComponentInParent<Entity>();
        if (e != null)
            _attr = e.Attr;
    }

    private void Update()
    {
        if (_attr != null)
        {
            if (BreakTrigger >= _attr.Health / _attr.MaxHealth)
            {

                SkinnedMeshRenderer rend = GetComponent<SkinnedMeshRenderer>();
                rend.materials = new Material[0];
                if(Remove != null)
                    Remove.materials = new Material[0];
                for (int i = 0; i < Amount; ++i)
                {
                    foreach (GameObject obj in FallOfPart)
                    {
                        Vector3 par = Random.insideUnitSphere;
                        GameObject help = Instantiate(obj);
                        help.transform.position = Root.position;
                        Rigidbody rgdb = help.GetComponent<Rigidbody>();

                        rgdb.AddForce(par * BreakForce);
                    }
                }

                enabled = false;
            }
        }
        else
        {
            Entity e = GetComponentInParent<Entity>();
            if (e != null)
                _attr = e.Attr;
        }
    }

}
