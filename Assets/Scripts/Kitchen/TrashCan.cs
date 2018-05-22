using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour {
    private CarrayObject _myCarray;
    private PlatePlace _myPlace;

	void Start () {
        _myCarray = GetComponent<CarrayObject>();
        if (_myCarray == null)
            Debug.LogError("CarrayObject Required");
        _myPlace = GetComponent<PlatePlace>();
        if (_myPlace == null)
            Debug.LogError("PlatePLace Object Required");
    }
	void Update () {
        if (_myCarray != null && !_myCarray.IsEmpty())
        {
            if (_myCarray.HasFood())
                _myCarray.GetFood();
            else
                Debug.LogError("notEmpty, but has no Food");
            Debug.Log("Destroy Object");
        }
        /* if (_myPlace != null && _myPlace.HasPlate())
        {
            // _myPlace.DEstroyPlate();
            Debug.Log("Destroy Plate");
        }*/
    }
}
