using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Annahme : MonoBehaviour {

    public GameObject SpawnObject;
    public WayPoint SpawnPosition;
    public MeetProducer[] partProducers;
    public int zombiesPerFoot = 5;

    private List<GameObject> _newZombies = null;
    public PlateProducer producer;
    private PlatePlace _pp;
    private Ordermanager _om;
    public float sriviceTime = 3F;

    public Prison prison;

    // Use this for initialization
    void Start () {
        _newZombies = new List<GameObject>();
        _pp = GetComponent<PlatePlace>();
        _om = GameObject.FindGameObjectWithTag("Orders").GetComponent<Ordermanager>();
	}

	private void InctrimentPlates()
    {
        producer.freePlates++;
    }

    // Update is called once per frame
	void Update () {
        if(_newZombies.Count > 0)
        {
            List<GameObject> buffer = new List<GameObject>();
            foreach (GameObject z in _newZombies)
            {
                AIFollowingPath ai = z.GetComponent<AIFollowingPath>();
                if (ai != null)
                {
                    ai.OnReachTarget += prison.AddZombie;
                    buffer.Add(z);
                }
            }
            foreach(GameObject z in buffer)
            {
                _newZombies.Remove(z);
            }
        }

        if (_pp.HasPlate())
        {
            if(_pp.Checkout(_om))
            {
                Vector3 off = new Vector3(3F, 0, 0);
                for (int i = 0; i < zombiesPerFoot; ++i)
                {
                    GameObject obj = Instantiate(SpawnObject);
                    obj.transform.position = SpawnPosition.transform.position + i * off;
                    FriendlyZombie help = obj.GetComponent<FriendlyZombie>();
                    help.Target = SpawnPosition;
                    _newZombies.Add(obj);
                }
            }
            _pp.DEstroyPlate();
            Invoke("InctrimentPlates", sriviceTime);
        }
	}
}
