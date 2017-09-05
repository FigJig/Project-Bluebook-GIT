using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossHealth : MonoBehaviour {

    public int startingHealth;
    public int currentHealth;

    public float sinkSpeed;

    public bool isDead, isSinking;

    public AudioClip deathClip;

    Animator anim;                          
    AudioSource bossAudio;                    
    ParticleSystem hitParticles;                
    BoxCollider boxCollider;            

    void Start () {
        currentHealth = startingHealth;

        isDead = false;
        isSinking = false;
	}

	void Update () {

        if (isSinking)
        {
            //Move the enemy down by the sinkSpeed per second.
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount)
    {

        if (isDead)
            // ... no need to take damage so exit the function.
            return;

         //bossAudio.Play();

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;

        // If the current health is less than or equal to zero
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        // Turn the collider into a trigger so shots can pass through it.
        // boxCollider.isTrigger = true;

        // Tell the animator that the enemy is dead.
        //anim.SetTrigger("Dead");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        //bossAudio.clip = deathClip;
        //bossAudio.Play();
    }


    public void StartDeathAnim()
    { 
        // Find and disable the Nav Mesh Agent.
        //GetComponent<NavMeshAgent>().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent<Rigidbody>().isKinematic = true;

        // The enemy should no sink.
        isSinking = true;

        // After 2 seconds destory the enemy.
        Destroy(gameObject, 2f);
    }
}

