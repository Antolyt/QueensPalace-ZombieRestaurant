using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    public float ForcePower;
    public int NumPlayer = 1;

    private string _inputPrefix;

    private Rigidbody _rgdb;
    private Vector3 _lastDir = Vector3.forward;


	// Use this for initialization
	void Start () {
        _inputPrefix = "P" + NumPlayer + "_";
        _rgdb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
        Vector3 dir = Vector3.zero;

        dir.x = Input.GetAxis(_inputPrefix + "Horizontal");
        dir.z = Input.GetAxis(_inputPrefix + "Vertical");

        if (dir.z != 0 || dir.x != 0)
        {
            dir.Normalize();
            _rgdb.AddForce(dir * ForcePower);
        }
    }

    public Vector3 GetShootDir()
    {
        Vector3 dir = new Vector3(Input.GetAxis(_inputPrefix + "Horizontal2"), 0, Input.GetAxis(_inputPrefix + "Vertical2"));

        if (dir.x != 0 || dir.z != 0)
        {
            _lastDir = dir.normalized;
            return dir.normalized;
        }
        else
            return _lastDir;
    }

    public bool GetAxisDown(string axis)
    {
        return Input.GetAxis(_inputPrefix + axis) != 0;
    }

    public bool GetButtonDown(string button)
    {
        return Input.GetButtonDown(_inputPrefix + button);
    }

    public bool GetButton(string button)
    {
        return Input.GetButton(_inputPrefix + button);
    }
}
