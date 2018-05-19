using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour {
    private CarrayObject _myCarray;
	

	void Start () {
        _myCarray = GetComponent<CarrayObject>();
        if (_myCarray == null)
            Debug.LogError("CarrayObject Required");
    }
	void Update () {
        if (_myCarray != null && !_myCarray.IsEmpty())
        {
            if (_myCarray.HasFood())
                _myCarray.GetFood();
            else if (_myCarray.HasPlate())
            {
                Destroy(_myCarray.GetPlate().gameObject);
                Debug.Log("Destroy Object");
            }
            else
                Debug.LogError("notEmpty, but has no Food nor Plate");
            Debug.Log("Destroy Object");
        }
    }
}
