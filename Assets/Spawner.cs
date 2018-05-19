using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float SpawnTime;
    public GameObject SpawnObject;

    double timer;
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= SpawnTime)
        {
            GameObject obj = Instantiate(SpawnObject);
            obj.transform.position = transform.position;

            FriendlyZombie ai = obj.GetComponent<FriendlyZombie>();
            if (ai != null)
            {
                WayPoint wayPoint = GetComponentInParent<WayPoint>();
                if (wayPoint != null)
                {
                    ai.Target = wayPoint;
                    ai.enabled = true;
                }
            }

            timer %= SpawnTime;
        }
	}
}
