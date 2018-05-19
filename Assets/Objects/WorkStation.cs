using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation : MonoBehaviour {
    public bool isProducer = false;
    private CarrayObject _myCarry;
    void OnTriggerEnter(Collider other) {
        // this.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    void OnTriggerStay(Collider other) {
        if (other.GetComponent<ColliderCounter>().CollideOnlyOnInteractivObject() && other.GetComponent<PlayerMovement>().GetButtonDown("B1")) {
            // this.GetComponent<MeshRenderer>().material.color = Color.yellow;
            CarrayObject otherCarry = other.GetComponent<CarrayObject>();
            if (!_myCarry.HasFood() && otherCarry.HasFood())
            {
                _myCarry.GiveFood(otherCarry.GetFood());
                if (!_myCarry.HasFood() || !otherCarry.IsEmpty())
                    Debug.LogError("TransactionFailed");
            }
            else if (_myCarry.HasFood() && otherCarry.IsEmpty())
            {
                otherCarry.GiveFood(_myCarry.GetFood());
                if (_myCarry.HasFood() || otherCarry.IsEmpty())
                    Debug.LogError("recive Failed");
            }
            else if (!isProducer && _myCarry.HasFood() && otherCarry.HasFood()) {
                Food buffer = otherCarry.GetFood();
                otherCarry.GiveFood(_myCarry.GetFood());
                _myCarry.GiveFood(buffer);
            }
        }
    }
    void OnTriggerExit(Collider other) {
        // this.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
	// Use this for initialization
	void Start () {
        _myCarry = this.GetComponent<CarrayObject>();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
