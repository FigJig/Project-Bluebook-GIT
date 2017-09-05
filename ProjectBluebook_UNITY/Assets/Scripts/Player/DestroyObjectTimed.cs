using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectTimed : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 6f);
	}
}
