using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NanoProbe : MonoBehaviour {

    GameObject nanoProjectilePrefab;
    public GameObject nanoProjectile, nanoBarrel;

	// Use this for initialization
	void Start () {
        Color greenInd = new Color(0f, 0.5514706f, 0.2662276f);
        Color redInd = new Color(0.5955882f, 0f, 0f);
    }

    // Update is called once per frame
    void Update () {
        Color greenInd = new Color(0f, 0.5514706f, 0.2662276f);
        Color redInd = new Color(0.5955882f, 0f, 0f);

        nanoProjectilePrefab = nanoProjectile;
        // Destroy(gameObject, 6f);

        if (Input.GetButtonDown("X Button"))
        {
            GameObject nanoProjectile = Instantiate(nanoProjectilePrefab) as GameObject;
            //projectile angle
            nanoProjectile.transform.rotation = nanoBarrel.transform.rotation;
            nanoProjectile.transform.position = nanoBarrel.transform.position + nanoBarrel.transform.forward * 1;
            Rigidbody rb = nanoProjectile.GetComponent<Rigidbody>();
            rb.velocity = nanoBarrel.transform.forward * 800;
        }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "ForceField")
        {
            Destroy(gameObject);
        }
    }
}
