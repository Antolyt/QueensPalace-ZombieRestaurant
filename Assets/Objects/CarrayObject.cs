using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrayObject : MonoBehaviour {

    private Food _food = null;

    public bool IsEmpty() {
        return _food == null;
    }
    public bool GiveFood(Food food) {
        if (_food == null)
        {
            Debug.Log("getFood");
            _food = food;
            return true;
        }
        else return false;
    }
    public Food GetFood() {
        Food f = _food;
        _food = null;
        return f;
    }

	void Start () {}
	void Update () {
        this.GetComponent<MeshRenderer>().material.color = IsEmpty() ? Color.red : Color.blue;
    }
}
