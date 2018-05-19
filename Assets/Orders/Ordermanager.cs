﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ordermanager : MonoBehaviour {
    private List<Order> _orders;
    public float spawnsPerSecond;
    private int _amountSpawnedOrders;

	void Start () {
    }
    public List<Order> GetOrders()
    {
        return _orders;
    }
	void Update () {
		if (Random.value < Time.deltaTime * spawnsPerSecond)
        {
            _orders.Add(new Order(_amountSpawnedOrders++));
        }
	}
}
