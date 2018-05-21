using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetProducer : MonoBehaviour {
    public Food.BodyPart part;
    public FootTransformer[] meats;
    public int amountStore = 1;
    private int _amtText = -1;
    private TextMesh _text = null;
    private FootTransformer _foodObj;
    private CarrayObject _myCarry;
	void Start () {
        GameObject.FindGameObjectWithTag("Memory").GetComponent<Memory>().SetAttribute(this);
        _foodObj = Instantiate(meats[(int)part], transform.position + new Vector3(0F, 0.3f), Quaternion.identity);
        _foodObj.transform.eulerAngles = new Vector3(-90F, 0F, 0F);
        _foodObj.transform.parent = transform;
        _myCarry = this.GetComponent<CarrayObject>();
        // _myCarry.GiveFood(new Food(part));
        _foodObj.SetFood(new Food(part));
        GameObject obj = transform.GetChild(0).gameObject;
        if (obj.name != "Amount")
            Debug.LogError("No Amount Obj");
        else
        {
            _text = obj.GetComponent<TextMesh>();
        }
    }
	void Update () {
        if(_text != null)
        {
            if (_amtText != amountStore)
            {
                _amtText = amountStore;
                _text.text = amountStore.ToString();
            }
        }
        if (!_myCarry.HasFood())
        {
            if (amountStore > 0)
            {
                _myCarry.GiveFood(new Food(part));
                if (!_foodObj.gameObject.activeSelf)
                {
                    _foodObj.gameObject.SetActive(true);
                }

                amountStore--;
            }
            else
            {
                if(_foodObj.gameObject.activeSelf)
                    _foodObj.gameObject.SetActive(false);
            }
        }
    }
}
