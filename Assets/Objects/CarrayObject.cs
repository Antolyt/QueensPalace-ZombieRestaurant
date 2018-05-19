using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrayObject : MonoBehaviour {

    private Food _food = null;
    public MeshRenderer meet;
    private MeshRenderer _footObj;
    private GameObject _plate = null;
    private bool _isWorstation;
    private bool _isPlayer;
    private Food.WorkStaitionType _type;
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
            _footObj.transform.parent = transform;
            _food = food;
            if (_isWorstation)
            {
                _footObj = Instantiate(meet, transform.position + new Vector3(0F, 2F), Quaternion.identity);
                return _food.PlaceOnWorkstation(_type);
            }
            return true;
        }
        else return false;
    }
    public Food GetFood() {
        if (_isWorstation)
        {
            _food.TakeFromWorkstation();
            Destroy(_footObj.gameObject);
        }
        Food f = _food;
        _food = null;
        return f;
    }
    public float GetFoodProgress() {
        if (_food == null)
            return -1F;
        return _food.GetProgress();
    }
    public Food GetFoodInfo() {
        return _food;
    }
	void Start () {
        WorkStation ws =  GetComponent<WorkStation>();
        if (ws == null)
            _isWorstation = false;
        else {
            _isWorstation = true;
            _type = ws.type;
            if (_type == Food.WorkStaitionType.NIX)
                _isWorstation = false;
        }
    }
	void Update () {
        GetComponent<MeshRenderer>().material.color = IsEmpty() ? Color.red : Color.blue;
        if (HasFood())
            _food.Update();
    }
}
