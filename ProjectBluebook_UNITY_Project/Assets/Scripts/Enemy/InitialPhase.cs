using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialPhase : MonoBehaviour {

    public GameObject mainBossModel;
    public GameObject whiteFlash;
    public bool beenHit;

	// Use this for initialization
	void Start () {
        beenHit = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(beenHit == true)
        {
            StartCoroutine(SpawnBoss());
        }

	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            beenHit = true;
        }
    }

    IEnumerator SpawnBoss()
    {
        whiteFlash.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        mainBossModel.SetActive(true);
        yield return null;
    }
}
