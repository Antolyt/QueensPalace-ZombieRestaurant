using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        this.GetComponent<MeshRenderer>().material.color = Color.red;
        Debug.Log("hit");
    }
    void OnTriggerExit(Collider other) {
        this.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
	// Use this for initialization
	void Start () {
        Debug.Log("Create");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
