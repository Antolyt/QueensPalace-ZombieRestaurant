using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeRemove : MonoBehaviour {

    public float LifeTime = 5f;

    double timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= LifeTime)
        {
            Destroy(gameObject);
        }
	}
}
