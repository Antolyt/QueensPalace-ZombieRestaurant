using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrayObject : MonoBehaviour {

    private Food _food = null;
    private FootTransformer _footObj;
    private GameObject _plate = null;
    private bool _isWorstation;
    private bool _isPlayer;
    private bool _isPlatePlace;
    private Food.WorkStaitionType _type;
    public FootTransformer[] mets = null;
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
            if (_isPlayer)
            {
                _plate.transform.localPosition = new Vector3(-1.93f, 2.5f, 0f);
            }
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
    public void UpdateFood()
    {
        if (HasFood() && _isPlayer || _isWorstation || _isPlatePlace)
        {
            _footObj.SetFood(_food);
        }
    }
    public bool GiveFood(Food food) {
        if (IsEmpty())
        {
            _food = food;
            if (_isWorstation || _isPlatePlace)
            {
                _footObj = Instantiate(mets[(int)food.part], transform.position + new Vector3(0F, 2F), Quaternion.identity);
                _footObj.transform.parent = transform;
                _footObj.SetFood(_food);
                return _food.PlaceOnWorkstation(_type, _footObj);
            }
            else if (_isPlayer)
            {
                _footObj = Instantiate(mets[(int)food.part], transform.position + new Vector3(0F, 0F, 2F), Quaternion.identity);
                _footObj.transform.parent = transform;
                _footObj.SetFood(_food);
            }
            return true;
        }
        else return false;
    }
    public Food GetFood() {
        if (_isWorstation || _isPlatePlace)
        {
            _food.TakeFromWorkstation();
            Destroy(_footObj.gameObject);
        }
        else if (_isPlayer)
        {
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
        GameObject.FindGameObjectWithTag("Memory").GetComponent<Memory>().SetAttribute(this);
        WorkStation ws =  GetComponent<WorkStation>();
        _isWorstation = false;
        _isPlayer = false;
        _isPlatePlace = false;
        if (ws == null)
        {            
            if (tag == "Player")
                _isPlayer = true;
            else
            {
                PlatePlace pp = GetComponent<PlatePlace>();
                if(pp != null)
                {
                    if (!pp.isDestructr && !pp.isProducer)
                        _isPlatePlace = true;
                }
            }

        }
        else
        {
            _isWorstation = true;
            _type = ws.type;
            if (_type == Food.WorkStaitionType.NIX)
                _isWorstation = false;
        }
    }
	void Update () {
        if (GetComponent<MeshRenderer>() != null)
            GetComponent<MeshRenderer>().material.color = IsEmpty() ? Color.red : Color.blue;
        if (HasFood())
            _food.Update();
    }
}
