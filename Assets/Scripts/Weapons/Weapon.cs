using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Weapon : MonoBehaviour {

    private Memory _memory;
    private PlayerMovement _input;

    public WeaponAttribute Attr = new WeaponAttribute();

    public delegate void DelOnShoot(Weapon weapon);
    public DelOnShoot OnShoot;

    private float timer = 0;


	// Use this for initialization
	void Start () {
        _memory = GameObject.FindGameObjectWithTag("Memory").GetComponent<Memory>();
        _input = GetComponent<PlayerMovement>();

        if(_input == null)
        {
            Debug.LogWarning("Input Not Found " + this);
            enabled = false;
        }

        if(_memory == null)
        {
            Debug.LogWarning("Memory not found " + this);
            enabled = false;
        }
        else
        {
            _memory.SetAttribute(this);
        }
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if(_input.GetButtonDown("B1"))
        {
            OnShoot(this);
        }
	}
}
