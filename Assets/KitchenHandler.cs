using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<WeaponHandler>().enabled = false;
            other.GetComponent<CarrayObject>().enabled = true;
            if (!other.GetComponent<CarrayObject>().IsEmpty())
                other.GetComponent<CarrayObject>().Hide(true);
            other.transform.GetChild(0).gameObject.SetActive(false);
            other.GetComponent<Animator>().SetBool("IsInKitchen", true);
            Debug.Log("Entetr Kitchen");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<WeaponHandler>().enabled = true;
            if (!other.GetComponent<CarrayObject>().IsEmpty())
                other.GetComponent<CarrayObject>().Hide(false);
            other.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Exit Kitchen");
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
