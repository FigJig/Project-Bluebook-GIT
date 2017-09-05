using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorOpac : MonoBehaviour {

    public Material monitor;

	// Use this for initialization
	void Start () {
        Color monitorColour = monitor.color;
        monitorColour.a = 1f;
        monitor.color = monitorColour;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
