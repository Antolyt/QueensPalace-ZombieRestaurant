using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void SetWapons(bool b, Collider other)
    {
        int chN = other.transform.childCount;
        for (int i = 0; i < chN; ++i)
        {
            GameObject go = other.transform.GetChild(i).gameObject;
            if (go.name == "Weapons")
            {
                go.SetActive(b);
                break;
            }
        }
    }
	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<WeaponHandler>().enabled = false;
            other.GetComponent<CarrayObject>().enabled = true;
            if (!other.GetComponent<CarrayObject>().IsEmpty())
                other.GetComponent<CarrayObject>().Hide(true);
            SetWapons(false, other);
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
            SetWapons(true, other);
            other.transform.GetChild(0).gameObject.SetActive(true);
            Debug.Log("Exit Kitchen");
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
