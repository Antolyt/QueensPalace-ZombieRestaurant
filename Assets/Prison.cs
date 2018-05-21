using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prison : MonoBehaviour {

    [SerializeField] private GameObject zombieLocation;
    [HideInInspector] public List<Transform> zombieLocations;
    public int numberOfZombies;
    public GameObject zombie;

    public MeetProducer[] meetProducers;

	// Use this for initialization
	void Start () {
        zombieLocations.AddRange(zombieLocation.GetComponentsInChildren<Transform>());
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void FillProducersAndRemoveZombie()
    {
        if(numberOfZombies > 0)
        {
            foreach (MeetProducer mP in meetProducers)
            {
                mP.amountStore += mP.amountPerZombie;
            }

            numberOfZombies--;
            if (numberOfZombies < 5)
            {
                Destroy(zombieLocations[numberOfZombies].GetChild(0));
            }
        }
    }

    public void AddZombie()
    {
        numberOfZombies++;
        if(numberOfZombies <= 5)
        {
            GameObject zombieCopy = Instantiate<GameObject>(zombie);
            zombieCopy.transform.parent = zombieLocations[numberOfZombies - 1];
            zombieCopy.transform.localPosition = Vector3.zero;
        }
    }
}
