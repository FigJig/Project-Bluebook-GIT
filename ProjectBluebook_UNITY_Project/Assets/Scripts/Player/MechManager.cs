using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class MechManager : MonoBehaviour {

    public bool attackMode;

    public GameObject[] atkModeInd;
    public GameObject[] defModeInd;
    public GameObject weapon, mechMovementAS, wepMovementAS, crosshair;

    public AudioClip modeChange;

    AudioSource mechAS;

    //Right stick = attack mode, Left stick = defense mode

	// Use this for initialization
	void Start () {
        attackMode = true;
        mechAS = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        MechAudio();
        WeaponCrosshairAudio();

        WeaponControl weaponStatus = weapon.GetComponent<WeaponControl>();

        if (Input.GetButtonDown("Left Stick Button") & attackMode == true & weaponStatus.dFactor == false & weaponStatus.bcFactor == false & weaponStatus.ceFactor == false & weaponStatus.effFactor == false)
        {
            mechAS.clip = modeChange;
            mechAS.PlayOneShot(mechAS.clip);

            attackMode = false;
            atkModeInd[0].SetActive(false);
            defModeInd[0].SetActive(true);

            atkModeInd[1].SetActive(false);
            defModeInd[1].SetActive(true);

        }

        if (Input.GetButtonDown("Right Stick Button") & attackMode == false)
        {
            mechAS.clip = modeChange;
            mechAS.PlayOneShot(mechAS.clip);

            attackMode = true;
            atkModeInd[0].SetActive(true);
            defModeInd[0].SetActive(false);

            atkModeInd[1].SetActive(true);
            defModeInd[1].SetActive(false);
        }
    }

    void MechAudio ()
    {
        var horizontalMov = CrossPlatformInputManager.GetAxis("RightJoystickHorizontal");
        var verticalMov = CrossPlatformInputManager.GetAxis("RightJoystickVertical");

        if (horizontalMov > 0.2f)
        {
            mechMovementAS.SetActive(true);
        }

        if (horizontalMov < -0.2f)
        {
            mechMovementAS.SetActive(true);
        }

        if(horizontalMov < 0.2f & horizontalMov > -0.2f & verticalMov < 0.2f & verticalMov > -0.2f)
        {
            mechMovementAS.SetActive(false);
        }

        if (verticalMov > 0.2f)
        {
            mechMovementAS.SetActive(true);
        }

        if (verticalMov < -0.2f)
        {
            mechMovementAS.SetActive(true);
        }
    }

    void WeaponCrosshairAudio()
    {
        var wepHorizontalMov = CrossPlatformInputManager.GetAxis("LeftJoystickHorizontal");
        var wepVerticalMov = CrossPlatformInputManager.GetAxis("LeftJoystickVertical");

        CrosshairControl crosshairScript = crosshair.gameObject.GetComponent<CrosshairControl>();

        if (wepHorizontalMov > 0.1f & crosshairScript.targetLocked == false)
        {
            wepMovementAS.SetActive(true);
        }

        if (wepHorizontalMov < -0.1f & crosshairScript.targetLocked == false)
        {
            wepMovementAS.SetActive(true);
        }

        if (wepHorizontalMov < 0.1f & wepHorizontalMov > -0.1f & wepVerticalMov < 0.1f & wepVerticalMov > -0.1f)
        {
            wepMovementAS.SetActive(false);
        }

        if (wepVerticalMov > 0.1f & crosshairScript.targetLocked == false)
        {
            wepMovementAS.SetActive(true);
        }

        if (wepVerticalMov < -0.1f & crosshairScript.targetLocked == false)
        {
            wepMovementAS.SetActive(true);
        }
    }


}
