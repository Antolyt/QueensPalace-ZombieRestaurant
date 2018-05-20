using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float SpawnTime;
    public GameObject SpawnObject;
    public int Amount;

    double timer;
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= SpawnTime)
        {
            for(int i = 0; i < Amount; ++i)
            {
                GameObject help = Instantiate(SpawnObject);
                help.transform.position = transform.position;

                FriendlyZombie ai = help.GetComponent<FriendlyZombie>();
                if (ai != null)
                {
                    WayPoint wayPoint = GetComponentInParent<WayPoint>();
                    if (wayPoint != null)
                    {
                        ai.Target = wayPoint;
                        ai.enabled = true;
                    }
                }
            }

            timer %= SpawnTime;
        }
	}
}
