using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject Follow;
    Vector3 _offset;

	// Use this for initialization
	void Start () {
        _offset = transform.position;
        _offset.y = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Follow.transform.position.x, transform.position.y, Follow.transform.position.z);
        transform.position += _offset;
	}
}
