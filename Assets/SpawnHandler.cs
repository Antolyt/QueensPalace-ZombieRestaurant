using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour {

    List<Spawner> _spawner;
    public int maxActivated;
    public int minActivated;
    public float ChangeTime;

    public static float changingTime;

    List<Spawner> _activated = new List<Spawner>();
    List<Spawner> _idle = new List<Spawner>();
    double timer;

    private void Awake()
    {
        changingTime = ChangeTime;
    }

    private void Start()
    {
        _spawner = new List<Spawner>();
        _spawner.AddRange(GetComponentsInChildren<Spawner>());
        foreach (Spawner sp in _spawner)
            sp.enabled = false;
        maxActivated = Mathf.Min(maxActivated, _spawner.Count);
        timer = double.MaxValue;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= ChangeTime)
        {
            timer = 0;

            foreach (Spawner sp in _activated)
                sp.enabled = false;

            _activated.Clear();
            _idle.Clear();

            _idle.AddRange(_spawner);

            for(int i = 0; i < Random.Range(minActivated, maxActivated); i++)
            {
                int index = Random.Range(0, _idle.Count);

                _activated.Add(_idle[index]);
                _idle[index].enabled = true;
                _idle.RemoveAt(index);
            }
        }
    }

}
