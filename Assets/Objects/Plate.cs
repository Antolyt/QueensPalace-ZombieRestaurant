using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour {
    private const int MAX_AMOUNT_FOOD = 3;
    private Food[] _foods;
    private int _amountFoods = 0;
    public int NumFreeSlots() {
        return MAX_AMOUNT_FOOD - _amountFoods;
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
	void Start () {
        _foods = new Food[MAX_AMOUNT_FOOD] { null , null, null};
    }
	void Update () {}
}
