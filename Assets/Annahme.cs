using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Annahme : MonoBehaviour {
    public PlateProducer producer;
    private PlatePlace _pp;
    private Ordermanager _om;
    public float sriviceTime = 3F;
    // Use this for initialization
    void Start () {
        _pp = GetComponent<PlatePlace>();
        _om = GameObject.FindGameObjectWithTag("Orders").GetComponent<Ordermanager>();
	}
	private void InctrimentPlates()
    {
        producer.freePlates++;
    }
	// Update is called once per frame
	void Update () {
        if (_pp.HasPlate())
        {
            if(_pp.Checkout(_om))
            {
                Debug.Log("Valid Food"); // BEtselllung angenommen
            }
            _pp.DEstroyPlate();
            Invoke("InctrimentPlates", sriviceTime);
        }
	}
}
