using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpin : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.right * Time.deltaTime * 15f);
        //transform.Rotate(Vector3.right * Time.deltaTime * 99999f);
    }
}
