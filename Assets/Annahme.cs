using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Annahme : MonoBehaviour {
    private PlatePlace _pp;
    private Ordermanager _om;
	// Use this for initialization
	void Start () {
        _pp = GetComponent<PlatePlace>();
        _om = GameObject.FindGameObjectWithTag("Orders").GetComponent<Ordermanager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (_pp.HasPlate())
        {
            _pp.Checkout(_om);
            _pp.DEstroyPlate();
        }
	}
}
