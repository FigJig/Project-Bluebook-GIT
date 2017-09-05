using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponControl : MonoBehaviour {

    GameObject projectilePrefab;

    public AudioSource secondaryAS, projectileAS;
    public AudioClip factorCalibrated;
    public AudioClip factorsReset;
    public AudioClip weaponFire;
    public AudioClip readyToFire;

    public GameObject projectile, weapon, mech, cameraObject, wepCrosshair;
    public Renderer dWepInd, bcWepInd, ceWepInd, effWepInd, projectileRend;

    public Image dInd, bcInd, ceInd, effInd;
    public Image dIndGlow, bcIndGlow, ceIndGlow, effIndGlow;

    public bool dFactor;
    public bool bcFactor;
    public bool ceFactor;
    public bool effFactor;
    public bool readyToFirePlayed;
    public bool clearUI;
    public bool resetTarget;

    public float coolDown;
    public float resetTargetCD;

    AudioSource weaponAS;
    Animator weaponAnimator;

    void Start ()
    {
        dFactor = false;
        bcFactor = false;
        ceFactor = false;
        effFactor = false;
        readyToFirePlayed = false;
        clearUI = false;
        resetTarget = false;

        weaponAS = gameObject.GetComponent<AudioSource>();
        weaponAnimator = gameObject.GetComponent<Animator>();
    }

	void Update () {

        Color greenInd = new Color(0f, 0.8602941f, 0.04153151f);
        Color redInd = new Color(0.8602941f, 0f, 0f);

        projectilePrefab = projectile;
        RemoveDigitalGlitch();
        RemoveTargetLock();

        //Distance calibration
        if (Input.GetKeyDown(KeyCode.A))
        {
            weaponAS.clip = factorCalibrated;
            weaponAS.PlayOneShot(weaponAS.clip);
            dWepInd.material.SetColor("_EmissionColor", greenInd);
            dFactor = true;
            dInd.gameObject.GetComponent<Image>().color = new Color32(0, 233, 12, 179);
            dIndGlow.gameObject.GetComponent<Image>().color = new Color32(0, 255, 12, 179);
        }

        //Bullet Chamber calibration
        if (Input.GetKeyDown(KeyCode.S))
        {
            weaponAS.clip = factorCalibrated;
            weaponAS.PlayOneShot(weaponAS.clip);
            bcWepInd.material.SetColor("_EmissionColor", greenInd);
            bcFactor = true;
            bcInd.gameObject.GetComponent<Image>().color = new Color32(0, 233, 12, 179);
            bcIndGlow.gameObject.GetComponent<Image>().color = new Color32(0, 255, 12, 179);
        }

        //Coriolis Effect calibration
        if (Input.GetKeyDown(KeyCode.D))
        {
            weaponAS.clip = factorCalibrated;
            weaponAS.PlayOneShot(weaponAS.clip);
            ceWepInd.material.SetColor("_EmissionColor", greenInd);
            ceFactor = true;
            ceInd.gameObject.GetComponent<Image>().color = new Color32(0, 233, 12, 179);
            ceIndGlow.gameObject.GetComponent<Image>().color = new Color32(0, 255, 12, 179);
        }

        //Enemy Field Frequency calibration
        if (Input.GetKeyDown(KeyCode.F))
        {
            weaponAS.clip = factorCalibrated;
            weaponAS.PlayOneShot(weaponAS.clip);
            effWepInd.material.SetColor("_EmissionColor", greenInd);
            effFactor = true;
            effInd.gameObject.GetComponent<Image>().color = new Color32(0, 233, 12, 179);
            effIndGlow.gameObject.GetComponent<Image>().color = new Color32(0, 255, 12, 179);
        }

        if (Input.GetButtonDown ("Start Button"))
        {
            weaponAS.clip = factorsReset;
            weaponAS.PlayOneShot(weaponAS.clip);

            dFactor = false;
            bcFactor = false;
            ceFactor = false;
            effFactor = false;
            readyToFirePlayed = false;

            dWepInd.material.SetColor("_EmissionColor", redInd);
            bcWepInd.material.SetColor("_EmissionColor", redInd);
            effWepInd.material.SetColor("_EmissionColor", redInd);
            ceWepInd.material.SetColor("_EmissionColor", redInd);
            projectileRend.material.SetColor("_EmissionColor", redInd);

            dInd.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);
            bcInd.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);
            ceInd.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);
            effInd.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);

            dIndGlow.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);
            bcIndGlow.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);
            ceIndGlow.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);
            effIndGlow.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);
        }

        if (readyToFirePlayed == false & dFactor == true & bcFactor == true & ceFactor == true & effFactor == true & mech.gameObject.GetComponent<MechManager>().attackMode == true)
        {
            secondaryAS.clip = readyToFire;
            secondaryAS.PlayOneShot(secondaryAS.clip);
            projectileRend.material.SetColor("_EmissionColor", greenInd);

            readyToFirePlayed = true;
        }

        if (Input.GetButtonDown("Right Bumper") & dFactor == true & bcFactor == true & ceFactor == true & effFactor == true & mech.gameObject.GetComponent<MechManager>().attackMode == true)
        {
            GameObject projectile = Instantiate(projectilePrefab) as GameObject;
            //projectile angle
            projectile.transform.rotation = weapon.transform.rotation;
            projectile.transform.position = weapon.transform.position + weapon.transform.forward * 1;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = weapon.transform.forward * 800;

            projectile.gameObject.GetComponent<ProjectileControl>().projectileAS = projectileAS;
            weaponAnimator.Play("Weapon_Firing");

            cameraObject.gameObject.GetComponent<Kino.DigitalGlitch>().intensity = 0.3f;
            CameraShake.Shake(0.5f, 15f);

            dFactor = false;
            bcFactor = false;
            ceFactor = false;
            effFactor = false;
            readyToFirePlayed = false;

            clearUI = true;
            coolDown = 0.5f;
            resetTarget = true;
            resetTargetCD = 3f;

            weaponAS.clip = weaponFire;
            weaponAS.PlayOneShot(weaponAS.clip);

            dWepInd.material.SetColor("_EmissionColor", redInd);
            bcWepInd.material.SetColor("_EmissionColor", redInd);
            effWepInd.material.SetColor("_EmissionColor", redInd);
            ceWepInd.material.SetColor("_EmissionColor", redInd);
            projectileRend.material.SetColor("_EmissionColor", redInd);

            dInd.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);
            bcInd.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);
            ceInd.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);
            effInd.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);

            dIndGlow.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);
            bcIndGlow.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);
            ceIndGlow.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);
            effIndGlow.gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 179);

            wepCrosshair.gameObject.GetComponent<CrosshairControl>().targetLocked = false;
        }
	}

    void RemoveDigitalGlitch()
    {
        if (clearUI == true)
        {
            coolDown -= 1f * Time.deltaTime;

            if (coolDown <= 0f)
            {
                cameraObject.gameObject.GetComponent<Kino.DigitalGlitch>().intensity = 0f;
                clearUI = false;
            }
        }
    }

    void RemoveTargetLock()
    {
        if (resetTarget == true)
        {
            resetTargetCD -= 1f * Time.deltaTime;

            if(resetTargetCD <= 0f)
            {
                projectile.gameObject.GetComponent<ProjectileControl>().targetLocked = false;
                resetTarget = false;
            }
        }
    }

}
