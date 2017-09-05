using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileParticleControl : MonoBehaviour {

    ParticleSystem explosion;
	
	// Update is called once per frame
	void Update () {
        ParticleSystem explosion = gameObject.GetComponent<ParticleSystem>();
        float totalDuration = explosion.duration + explosion.startLifetime;
        Destroy(gameObject, totalDuration);
    }
}
