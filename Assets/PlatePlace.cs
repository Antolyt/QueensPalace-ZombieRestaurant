using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatePlace : MonoBehaviour {

    public GameObject plate = null;

    void OnTriggerStay(Collider other) {
        if ( other.GetComponent<ColliderCounter>().CollideOnlyOnInteractivObject() && other.GetComponent<PlayerMovement>().GetButtonDown("B1")) {
            CarrayObject otherCarry = other.GetComponent<CarrayObject>();
            if (otherCarry.HasPlate() && plate == null) {
                plate = otherCarry.GetPlate();
                plate.transform.parent = this.GetComponent<Transform>();
                plate.transform.localPosition = new Vector3(0F, 0F, 0F);
                if (plate == null)
                    Debug.LogError("no GameObject");
            }
            else if (otherCarry.IsEmpty() && plate != null) {
                plate.transform.parent = null;
                Debug.Log("give Plate");
                otherCarry.GivePlate(plate);
                plate = null;
                if (!otherCarry.HasPlate())
                    Debug.LogError("no Plate recived");
            }
        }
    }

	void Start () {}
	void Update () {}
}
