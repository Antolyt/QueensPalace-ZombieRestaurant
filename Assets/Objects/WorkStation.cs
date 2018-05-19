using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation : MonoBehaviour {
    public bool isProducer = false;
    private TimerSphere _timer;
    private bool _timerVis = false;
    public Food.WorkStaitionType type;
    private CarrayObject _myCarry;

    void OnTriggerEnter(Collider other) {
        // this.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    void OnTriggerStay(Collider other) {
        if (other.GetComponent<ColliderCounter>().CollideOnlyOnInteractivObject() && other.GetComponent<PlayerMovement>().GetButtonDown("B1")) {
            // this.GetComponent<MeshRenderer>().material.color = Color.yellow;
            CarrayObject otherCarry = other.GetComponent<CarrayObject>();
            if (!isProducer && !_myCarry.HasFood() && otherCarry.HasFood())
            {
                Food.WorkStaitionType pFWT = otherCarry.GetFoodInfo().GetFirstStation();
                if (pFWT != Food.WorkStaitionType.NIX && pFWT != type)
                    return;
                _myCarry.GiveFood(otherCarry.GetFood());
                if (!_myCarry.HasFood() || !otherCarry.IsEmpty())
                    Debug.LogError("resive failed");
            }
            else if (_myCarry.HasFood() && otherCarry.IsEmpty())
            {
                otherCarry.GiveFood(_myCarry.GetFood());
                if (_myCarry.HasFood() || otherCarry.IsEmpty())
                    Debug.LogError("givaway failed");
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
        _timer = GetComponentInChildren<TimerSphere>();
        if (_timer != null)
            _timer.gameObject.SetActive(_timerVis);
    }
	
	// Update is called once per frame
	void Update () {
        if (!isProducer && _myCarry.HasFood())
        {
            if (_myCarry.GetFoodInfo().state == Food.FoodState.BLACK)
            {
                if (_timerVis)
                {
                    _timer.StopBlink();
                    _timerVis = false;
                    _timer.gameObject.SetActive(_timerVis);
                }
            }
            else if (_myCarry.GetFoodInfo().HasReachedTargetState())
                _timer.StartBlink();
            else
            {
                if(!_timerVis)
                {
                    _timerVis = true;
                    _timer.gameObject.SetActive(_timerVis);
                }
                _timer.SetProgress(_myCarry.GetFoodProgress());
            }
        }
	}
}
