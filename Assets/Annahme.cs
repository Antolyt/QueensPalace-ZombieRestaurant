using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Annahme : MonoBehaviour {

    public GameObject SpawnObject;
    public WayPoint SpawnPosition;

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

    void IncrementIngredients()
    {
        //+++++++++
    }

	// Update is called once per frame
	void Update () {
        if (_pp.HasPlate())
        {
            if(_pp.Checkout(_om))
            {
                GameObject obj = Instantiate(SpawnObject);
                obj.transform.position = SpawnPosition.transform.position;

                FriendlyZombie help = obj.GetComponent<FriendlyZombie>();
                help.Target = SpawnPosition;

                AIFollowingPath ai = obj.GetComponent<AIFollowingPath>();
                ai.OnReachTarget += IncrementIngredients;
            }
            _pp.DEstroyPlate();
            Invoke("InctrimentPlates", sriviceTime);
        }
	}
}
