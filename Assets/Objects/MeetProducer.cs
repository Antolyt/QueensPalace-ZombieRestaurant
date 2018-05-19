using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetProducer : MonoBehaviour {
    private CarrayObject _myCarry;
	void Start () {
        _myCarry = this.GetComponent<CarrayObject>();
        _myCarry.GiveFood(new Food(Food.BodyPart.SPARRIPS));
    }
	void Update () {
        if(!_myCarry.HasFood())
            _myCarry.GiveFood(new Food(Food.BodyPart.SPARRIPS));
    }
}
