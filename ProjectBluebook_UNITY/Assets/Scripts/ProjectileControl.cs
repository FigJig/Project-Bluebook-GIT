using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControl : MonoBehaviour {

    public Transform explosionPrefab, buildingExplosionPrefab;
    public GameObject currentTarget, projPrefab;
    public int damageAmount;
    public bool targetLocked;
    public AudioSource projectileAS;
    public AudioClip[] projectileAC;

    void Update()
    {
        Destroy(gameObject, 6f);

        if (targetLocked)
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, 800 * Time.deltaTime);
    }

    void OnCollisionEnter (Collision other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(explosionPrefab, pos, rot);
            Destroy(gameObject);

            if (other.gameObject.GetComponent<FirstBossHealth>() != null)
            {
                other.gameObject.GetComponent<FirstBossHealth>().TakeDamage(damageAmount);
            }
        }

        if (other.gameObject.tag == "WeakPoint")
        {
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(explosionPrefab, pos, rot);
            Destroy(gameObject);

            if (other.gameObject.GetComponent <WeakPointHealth>() != null)
            {
                other.gameObject.GetComponent<WeakPointHealth>().TakeDamage(damageAmount);
            }
        }

        if (other.gameObject.tag == "Building")
        {
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(buildingExplosionPrefab, pos, rot);
            projectileAS.clip = projectileAC[0];
            projectileAS.PlayOneShot(projectileAS.clip);

            Destroy(gameObject);
        }
                
    }
}
