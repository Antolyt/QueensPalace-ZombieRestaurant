using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    public float ForcePower;
    public int NumPlayer = 1;

    private string _inputPrefix;

    private Rigidbody _rgdb;
    private Vector3 _lastDir = Vector3.forward;
    private Animator _animator;


    // Use this for initialization
    void Start()
    {
        _inputPrefix = "P" + NumPlayer + "_";
        _rgdb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
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
            if (_animator != null)
                _animator.SetBool("Walk", true);
        }
        else
        {
            if (_animator != null)
                _animator.SetBool("Walk", false);
        }

        Vector3 prefDir = new Vector3(Input.GetAxis(_inputPrefix + "Horizontal2"), 0, Input.GetAxis(_inputPrefix + "Vertical2"));
        if (!prefDir.Equals(Vector3.zero))
        {
            transform.rotation = Quaternion.LookRotation(prefDir);
            transform.Rotate(new Vector3(0, 90, 0));
        }
        else if(!dir.Equals(Vector3.zero))
        {
            transform.rotation = Quaternion.LookRotation(dir);
            transform.Rotate(new Vector3(0, 90, 0));
        }
    }

    public Vector3 GetShootDir()
    {
        Vector3 dir = this.transform.rotation * Quaternion.Euler(0, -90, 0) *  Vector3.forward;

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
