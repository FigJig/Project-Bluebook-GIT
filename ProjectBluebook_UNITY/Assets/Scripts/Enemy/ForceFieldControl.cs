using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldControl : MonoBehaviour {

    public Material forceFieldMat;
    Animator forcefieldAnim;

	// Use this for initialization
	void Start () {
        forcefieldAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NanoProbe")
        {
            //forceFieldMat.SetFloat("_Opacity", 0.67f);
            forcefieldAnim.Play("ForceFieldOpacityAnim");
        }
    }

}
