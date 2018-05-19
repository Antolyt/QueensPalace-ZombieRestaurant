using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Entity : MonoBehaviour {

    public EntityAttribute Attr;

    Memory _memory;
    protected Rigidbody _rgdb;
    BaseAI _aiScript;

    // Use this for initialization
    protected virtual void Start () {

        _memory = GameObject.FindGameObjectWithTag("Memory").GetComponent<Memory>();
        _rgdb = GetComponent<Rigidbody>();

        if (_memory == null)
        {
            Debug.LogWarning("Memory not found");
            enabled = false;
        }
        else
        {
            _memory.SetAttribute(this);
        }

        if (Attr.AIScript != null)
        {
            _aiScript = (BaseAI)gameObject.AddComponent(Attr.AIScript);
            _aiScript.Attr = Attr;
        }

        if(Attr.AttackScript != null)
        {
            gameObject.AddComponent(Attr.AttackScript);
        }
    }
	
	// Update is called once per frame
	protected virtual void Update () {

        if (Attr.Health <= 0)
            Destroy(gameObject);
	}
}
