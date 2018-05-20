﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatePlace : MonoBehaviour {

    public GameObject plate = null;
    private CarrayObject _carray = null;
    public bool isProducer = false;
    public bool isDestructr = false;
    public bool isTrash = false;

    public bool HasPlate() { return plate != null; }
    public void DEstroyPlate() { if (isDestructr) {Destroy(plate.gameObject); plate = null; } }
    public void Checkout (Ordermanager om)
    {
        if (plate != null)
            plate.GetComponent<Plate>().Checkout(om);
    }
    public void RescivePlate(Plate newPlate)
    {
        if (plate != null)
            Destroy(plate);
        plate = newPlate.gameObject;
        plate.transform.parent = transform;
        if (isProducer)
            plate.transform.localPosition = new Vector3(0F, 2.5f, 0.8f);
        else
            plate.transform.localPosition = new Vector3(0F, 0F, 0F);
    }
    void OnTriggerStay(Collider other) {
        if ( other.GetComponent<ColliderCounter>().CollideOnlyOnInteractivObject() && other.GetComponent<PlayerMovement>().GetButtonDown("B1")) {
            CarrayObject otherCarry = other.GetComponent<CarrayObject>();
            if (otherCarry == null)
                Debug.LogError("no Carray");
            if (!isDestructr && !isProducer && otherCarry.HasPlate() && plate != null)
            {
                GameObject pl = otherCarry.GetPlate();
                plate.transform.parent = null;
                otherCarry.GivePlate(plate);
                plate = pl;
                plate.transform.parent = GetComponent<Transform>();
                plate.transform.localPosition = new Vector3(0F, 0F, 0F);
                if (plate == null)
                    Debug.LogError("no GameObjectz");
            }
            else if (!isProducer && otherCarry.HasPlate() && plate == null) {
                if (isTrash)
                {
                    otherCarry.ClearPlate();
                }
                else
                {
                    plate = otherCarry.GetPlate();
                    plate.transform.parent = GetComponent<Transform>();
                    plate.transform.localPosition = new Vector3(0F, 0F, 0F);
                }
                if (_carray.HasFood())
                {
                    if (plate.GetComponent<Plate>().PlaceFood(_carray.GetFoodInfo()))
                        _carray.GetFood();
                    else
                    {
                        otherCarry.GiveFood(_carray.GetFood());     // Teller darv nur platziert werdeb wenn, wenn essen da liegt nur platzieren wenn es hinpasst, ansonsten switch
                    }
                }
                if (plate == null && !isTrash)
                    Debug.LogError("no GameObject");
            }
            else if (!isDestructr && !otherCarry.HasPlate() && plate != null) {
                if (otherCarry.HasFood())
                {
                    if (plate.GetComponent<Plate>().PlaceFood(otherCarry.GetFoodInfo()))
                    {
                        otherCarry.GetFood();
                    }
                    else
                    {
                        _carray.GiveFood(otherCarry.GetFood());
                    }
                }
                plate.transform.parent = null;
                Debug.Log("give Plate");
                otherCarry.GivePlate(plate);
                plate = null;
                if (!otherCarry.HasPlate())
                    Debug.LogError("no Plate recived");
            }
            else if(otherCarry.HasFood() && _carray.IsEmpty())
            {
                if (plate != null)
                {
                    if (plate.GetComponent<Plate>().PlaceFood(otherCarry.GetFoodInfo()))
                    {
                        otherCarry.GetFood();
                    }
                }
                else
                    _carray.GiveFood(otherCarry.GetFood());
            }
            else if(otherCarry.IsEmpty() && _carray.HasFood())
            {
                otherCarry.GiveFood(_carray.GetFood());
            }
        }
    }

	void Start () {
        _carray = GetComponent<CarrayObject>();
        if (_carray == null)
            Debug.LogError("require GetComponent");
    }
	void Update () {}
}
