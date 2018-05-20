using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour {
    private const int MAX_AMOUNT_FOOD = 3;
    public FootTransformer[] mets = null;
    private FootTransformer[] _assets;
    private Food[] _foods;
    private int _amountFoods = 0;
    public int NumFreeSlots() {
        return MAX_AMOUNT_FOOD - _amountFoods;
    }
    public void Checkout(Ordermanager om)
    {
        om.AceptPlate(_foods);
    }
    private bool IsAlreadyOnPlate(Food food) {
        foreach (Food f in _foods)
        {
            if (f == null)
                continue;
            if (f.state == food.state && f.part == food.part)
                return true;
        }
        return false;
    }
    public bool PlaceFood(Food food) {
        if (_amountFoods < MAX_AMOUNT_FOOD && food.Eatebal() && !IsAlreadyOnPlate(food))
        {
            _foods[_amountFoods++] = food;
            _assets[_amountFoods - 1] = Instantiate(mets[(int)food.part], new Vector3(), Quaternion.identity);
            _assets[_amountFoods - 1].transform.eulerAngles = new Vector3(-90F, 0F, 0F);
            _assets[_amountFoods - 1].transform.parent = transform;
            _assets[_amountFoods - 1].transform.localPosition = new Vector3(0f, 0f, 0.002f);
            // _assets[_amountFoods - 1].transform.localEulerAngles = new Vector3(0F, 0F, -93F);
            // _assets[_amountFoods - 1].transform.localScale = new Vector3(0.13f, 0.125f, 0.37f);
            _assets[_amountFoods - 1].SetFood(_foods[_amountFoods-1]);
            Color c;
            switch (_amountFoods) {
                case 1: c = Color.yellow;
                    break;
                case 2: c = Color.green;
                    break;
                case 3: c = Color.cyan;
                    break;
                default: c = Color.white;
                    break;
            }
            foreach (MeshRenderer m in GetComponents<MeshRenderer>())
            {
                m.material.color = c;
            }
            return true;
        }
        return false;
    }
    public void ClearPlate()
    {
        _amountFoods = 0;
        _foods = new Food[MAX_AMOUNT_FOOD];
        foreach (FootTransformer ft in _assets)
            Destroy(ft.gameObject);
        Color c = Color.white;
        foreach (MeshRenderer m in GetComponents<MeshRenderer>())
        {
            m.material.color = c;
        }
    }
	void Start () {
        GameObject.FindGameObjectWithTag("Memory").GetComponent<Memory>().SetAttribute(this);
        _foods = new Food[MAX_AMOUNT_FOOD] { null , null, null};
        _assets = new FootTransformer[MAX_AMOUNT_FOOD] { null, null, null};
    }
	void Update () {}
}
