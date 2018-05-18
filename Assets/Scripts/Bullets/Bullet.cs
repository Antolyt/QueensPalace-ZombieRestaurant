using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public BulletAttribute Attr = new BulletAttribute();

    Memory _memory;

    // Use this for initialization
    void Start()
    {
        _memory = GameObject.FindGameObjectWithTag("Memory").GetComponent<Memory>();

        if (_memory == null)
        {
            Debug.LogWarning("Memory not found");
            enabled = false;
        }
        else
        {
            _memory.SetAttribute(this);
        }
    }

}
