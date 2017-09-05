using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldControl : MonoBehaviour {

    public GameObject weapon, mech;
    public AudioClip shieldAudio;

    AudioSource shieldAS;
    Animator shieldAnimator;

	// Use this for initialization
	void Start () {

        weapon.gameObject.GetComponent<WeaponControl>();
        shieldAnimator = gameObject.GetComponent<Animator>();
        shieldAS = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Left Bumper") & mech.gameObject.GetComponent<MechManager>().attackMode == false)
        {
            shieldAnimator.Play("Shield_deploying");
        }

	}

    public void PlayShieldAudio()
    {
        shieldAS.clip = shieldAudio;
        shieldAS.PlayOneShot(shieldAS.clip);
    }
}
