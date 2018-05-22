using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCounter : MonoBehaviour {
    private int _collWork = 0, _collPlace = 0, _collTrash = 0;
    public bool CollideOnlyOnInteractivObject() {
        return _collWork + _collPlace + _collTrash== 1;
    }
    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<WorkStation>() != null)
            _collWork++;
        else if (other.GetComponent<PlatePlace>() != null)
            _collPlace++;
        else if (other.GetComponent<TrashCan>() != null)
            _collTrash++;
        Debug.Log("Work: " + _collWork.ToString() + "\nPlace: "+_collPlace.ToString() + "-" + _collTrash.ToString());
    }
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<WorkStation>() != null)
            _collWork--;
        else if (other.GetComponent<PlatePlace>() != null)
            _collPlace--;
        else if (other.GetComponent<TrashCan>() != null)
            _collTrash--;
        if (_collPlace < 0 || _collWork < 0 || _collTrash < 0)
            Debug.LogError("negativ Collision Counter");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
