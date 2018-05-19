using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootTransformer : MonoBehaviour {
    private Food _food = null;
    public void UpdteFood()
    {
        Color c;
        switch (_food.state)
        {
            case Food.FoodState.RAW: c = Color.white; break;
            case Food.FoodState.BLACK: c = Color.black; break;
            default: c = Color.red; break;
        }
        GetComponent<MeshRenderer>().material.color = c;
    }
    public void SetFood(Food foot)
    {
        _food = foot;
        UpdteFood();
    }
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
