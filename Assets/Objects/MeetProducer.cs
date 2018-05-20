using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetProducer : MonoBehaviour {
    public Food.BodyPart part;
    public FootTransformer[] meats;
    private FootTransformer _foodObj;
    private CarrayObject _myCarry;
	void Start () {
        GameObject.FindGameObjectWithTag("Memory").GetComponent<Memory>().SetAttribute(this);
        _foodObj = Instantiate(meats[(int)part], transform.position + new Vector3(0F, 0.3f), Quaternion.identity);
        _foodObj.transform.eulerAngles = new Vector3(-90F, 0F, 0F);
        _foodObj.transform.parent = transform;
        _myCarry = this.GetComponent<CarrayObject>();
        _myCarry.GiveFood(new Food(part));
        _foodObj.SetFood(_myCarry.GetFoodInfo());
    }
	void Update () {
        if(!_myCarry.HasFood())
            _myCarry.GiveFood(new Food(part));
    }
}
