using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateProducer : MonoBehaviour {
    public GameObject _plate;
    private PlatePlace _myPP;
    public int freePlates = 0;
	// Use this for initialization
	void Start () {
        _myPP = GetComponent<PlatePlace>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!_myPP.HasPlate() && freePlates > 0)
        {
            freePlates--;
            GameObject p = Instantiate(_plate, new Vector3(), Quaternion.identity);
            p.transform.eulerAngles = new Vector3(-90F, 0F, 0F);
            _myPP.RescivePlate(p.GetComponent<Plate>());
        }
	}
}
