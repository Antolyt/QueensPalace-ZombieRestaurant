using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrayObject : MonoBehaviour {

    private Food _food = null;
    private GameObject _plate = null;
    public bool HasFood() {
        return _food != null;
    }
    public bool HasPlate() {
        return _plate != null;
    }
    public bool IsEmpty() {
        return _food == null && _plate == null;
    }
    public bool GivePlate(GameObject plate) {
        if(IsEmpty())
        {
            _plate = plate;
            _plate.transform.parent = this.GetComponent<Transform>();
            return true;
        }
        return false;
    }
    public GameObject GetPlate() {
        _plate.transform.parent = null;
        GameObject buffer = _plate;
        _plate = null;
        return buffer;
    }
    public bool GiveFood(Food food) {
        if (IsEmpty())
        {
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

	void Start () {
    }
	void Update () {
        this.GetComponent<MeshRenderer>().material.color = IsEmpty() ? Color.red : Color.blue;
    }
}
