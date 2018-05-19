using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetProducer : MonoBehaviour {
    private CarrayObject _myCarry;
    private Food _head = new Food(Food.BodyPart.HEAD);
	void Start () {
        _myCarry = this.GetComponent<CarrayObject>();
        _myCarry.GiveFood(_head);
    }
	void Update () {
        _myCarry.GiveFood(_head);
    }
}
