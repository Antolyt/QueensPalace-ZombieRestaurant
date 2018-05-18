using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    public float ForcePower;
    public int NumPlayer;

    private string _inputPrefix;

    private Rigidbody _rgdb;


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
}
