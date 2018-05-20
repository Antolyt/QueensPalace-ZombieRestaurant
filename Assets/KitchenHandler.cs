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
            other.GetComponentInChildren<Pistol>().gameObject.SetActive(false);
            other.GetComponent<Animator>().SetBool("IsInKitchen", true);
            Debug.Log("Entetr Kitchen");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<WeaponHandler>().enabled = true;
            other.GetComponentInChildren<Pistol>().gameObject.SetActive(true);
            other.GetComponent<Animator>().SetBool("IsInKitchen", false);
            Debug.Log("Exit Kitchen");
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
