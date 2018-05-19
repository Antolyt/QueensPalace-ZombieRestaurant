using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCounter : MonoBehaviour {
    private int _collWork = 0, _collPlace = 0;
    public bool CollideOnlyOnInteractivObject() {
        return _collWork + _collPlace == 1;
    }
    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<WorkStation>() != null)
            _collWork++;
        else if (other.GetComponent<PlatePlace>() != null)
            _collPlace++;
        Debug.Log("Work: " + _collWork.ToString() + "\nPlace: "+_collPlace.ToString());
    }
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<WorkStation>() != null)
            _collWork--;
        else if (other.GetComponent<PlatePlace>() != null)
            _collPlace--;
        if (_collPlace < 0 || _collWork < 0)
            Debug.LogError("negativ Collision Counter");
        Debug.Log("Work: " + _collWork.ToString() + "\nPlace: " + _collPlace.ToString());
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
