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
    private Transform _lefthand = null;
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
            _plate.transform.parent = GetComponent<Transform>();
            if (_isPlayer)
            {
                GetComponent<Animator>().SetBool("HasPlate", true);
                _plate.transform.localPosition = new Vector3(-1.93f, 2.5f, -0.5f);
                _plate.transform.parent = _lefthand;
            }
            return true;
        }
        return false;
    }
    public void ClearPlate()
    {
        if (_plate != null)
            _plate.GetComponent<Plate>().ClearPlate();
    }
    public GameObject GetPlate() {
        if (_plate == null)
            return null;
        if(_isPlayer)
        {
            GetComponent<Animator>().SetBool("HasPlate", false);
        }
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
    public bool AddFoodToPlate(Food food)
    {
        return _plate.GetComponent<Plate>().PlaceFood(food);
    }
    public bool GiveFood(Food food) {
        if (IsEmpty())
        {
            _food = food;
            if (_isWorstation || _isPlatePlace)
            {
                if (_type == Food.WorkStaitionType.PFANNE)
                {
                    _footObj = Instantiate(mets[(int)food.part], transform.position, Quaternion.identity);
                    _footObj.transform.parent = transform;
                    _footObj.transform.localEulerAngles = new Vector3(-90F, 0F, 0F);
                    _footObj.transform.localPosition = new Vector3(0F, 1.7f, 0F);
                }
                else
                {
                    _footObj = Instantiate(mets[(int)food.part], transform.position + new Vector3(0F, 0.2f), Quaternion.identity);
                    _footObj.transform.eulerAngles = new Vector3(-90F, 0F, 0F);
                    _footObj.transform.parent = transform;
                }
                _footObj.SetFood(_food);
                return _food.PlaceOnWorkstation(_type, _footObj);
            }
            else if (_isPlayer)
            {
                GetComponent<Animator>().SetBool("HasPlate", true);
                _footObj = Instantiate(mets[(int)food.part], new Vector3() , Quaternion.identity);
                _footObj.transform.parent = transform;
                _footObj.transform.localPosition = new Vector3(-1.93f, 2.9f, -0.5f);
                _footObj.transform.localEulerAngles = new Vector3(90F, 0F, 0F);
                _footObj.transform.parent = _lefthand;
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
            GetComponent<Animator>().SetBool("HasPlate", false);
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
    public void Hide(bool flag)
    {
        if (_footObj != null)
            _footObj.gameObject.SetActive(flag);
        if (_plate != null)
            _plate.SetActive(flag);
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
            {
                _isPlayer = true;
                // GetComponent<Animator>().SetBool("IsInKitchen", true);
                // GetComponentInChildren<Pistol>().gameObject.SetActive(false);
                _lefthand = gameObject.transform.GetChild(1).GetChild(0).GetChild(0);
                if (_lefthand == null)
                    Debug.LogError("no Object with name Left Hand");
            }
            else
            {
                PlatePlace pp = GetComponent<PlatePlace>();
                if (pp != null)
                {
                    if (!pp.isDestructr)
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
