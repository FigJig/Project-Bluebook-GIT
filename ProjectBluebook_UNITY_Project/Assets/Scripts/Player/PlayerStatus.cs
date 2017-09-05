using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public int startingPlayerHealth;
    public int currentPlayerHealth;
    public bool isDead;
    public GameObject mCamera;

	// Use this for initialization
	void Start () {
        currentPlayerHealth = startingPlayerHealth;
        isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
