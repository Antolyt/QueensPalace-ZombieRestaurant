using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation : MonoBehaviour {
    public bool isProducer = false;
    public bool isDestructor = false;
    private TimerSphere _timer;
    private bool _timerVis = false;
    public Food.WorkStaitionType type;
    private CarrayObject _myCarry;
    private ParticleSystem _smoke;

    void OnTriggerEnter(Collider other) {
        // this.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    private float Cap(float min, float max, float val)
    {
        if (val < min)
            return min;
        if (val > max)
            return max;
        return val;
    }
    void OnTriggerStay(Collider other) {
        if (other.GetComponent<ColliderCounter>().CollideOnlyOnInteractivObject() && other.GetComponent<PlayerMovement>().GetButtonDown("B1")) {
            // this.GetComponent<MeshRenderer>().material.color = Color.yellow;
            CarrayObject otherCarry = other.GetComponent<CarrayObject>();
            if (!isProducer && !_myCarry.HasFood() && otherCarry.HasFood())
            {
                Debug.Log("getFood");
                Food.WorkStaitionType pFWT = otherCarry.GetFoodInfo().GetFirstStation();
                if (pFWT != Food.WorkStaitionType.NIX && pFWT != type)
                    return;
                _myCarry.GiveFood(otherCarry.GetFood());
                if (!_myCarry.HasFood() || !otherCarry.IsEmpty())
                    Debug.LogError("resive failed");
            }
            else if (!isDestructor && _myCarry.HasFood() && otherCarry.IsEmpty())
            {
                Debug.Log("give Food");
                otherCarry.GiveFood(_myCarry.GetFood());
                if (_myCarry.HasFood() || otherCarry.IsEmpty())
                    Debug.LogError("givaway failed");
                if (!isProducer)
                {
                    _timerVis = false;
                    _timer.gameObject.SetActive(_timerVis);
                    // _timer.SetProgress(Cap(0F, 1F,_myCarry.GetFoodProgress()));
                }
            }
            else if (!isDestructor && !isProducer && _myCarry.HasFood() && otherCarry.HasFood()) {
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
        _smoke = GetComponent<ParticleSystem>();
        _myCarry = GetComponent<CarrayObject>();
        if (!isProducer)
        {
            _timer = GetComponentInChildren<TimerSphere>();
            if (_timer != null)
                _timer.gameObject.SetActive(_timerVis);
        }
        if (_smoke != null)
            _smoke.Stop();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isDestructor && !isProducer && _myCarry.HasFood())
        {
            if (_myCarry.GetFoodInfo().state == Food.FoodState.BLACK)
            {
                if (_timerVis && _timer.isActiveAndEnabled)
                {
                    _timer.StopBlink();
                    _timerVis = false;
                    _timer.gameObject.SetActive(_timerVis);
                }
                if (_smoke != null && !_smoke.isPlaying)
                    _smoke.Play();
            }
            else if (_myCarry.GetFoodInfo().HasReachedTargetState())
            {
                if (!_timerVis)
                {
                    _timerVis = true;
                    _timer.gameObject.SetActive(_timerVis);
                }
                if (!_timer.IsBlinking())
                {
                    _timer.StartBlink();
                    Debug.Log("Start blink");
                }
            }
            else
            {
                if (!_timerVis)
                {
                    _timerVis = true;
                    _timer.gameObject.SetActive(_timerVis);
                }
                _timer.SetProgress(_myCarry.GetFoodProgress());
            }
        }
        else
        {
            if (_smoke != null && _smoke.isPlaying)
                _smoke.Stop();
            if (_timer != null && _timer.IsBlinking())
                _timer.StopBlink();
        }
	}
}
