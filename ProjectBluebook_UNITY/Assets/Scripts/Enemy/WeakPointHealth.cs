using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointHealth : MonoBehaviour {

    public GameObject boss;
    public int startingHealth;
    public int currentHealth;
    public int deathDamage;
    public bool isDead;

	void Start () {
        currentHealth = startingHealth;
        isDead = false;
	}

    public void TakeDamage(int amount)
    {
        if (isDead)
            return;

        currentHealth -= amount;


        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        boss.gameObject.GetComponent<FirstBossHealth>().TakeDamage(deathDamage);
        isDead = true;
    }
}
