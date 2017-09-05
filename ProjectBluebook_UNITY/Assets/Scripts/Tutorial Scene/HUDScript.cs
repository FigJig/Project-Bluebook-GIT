using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

    public GameObject mechScreen, objectHUD;
    public Material HUD;
    public Image mechCrosshair, weaponCrosshair;

    public float fadeCD;
    public bool fadeOutHud = true;

    void Awake()
    {
        Color hudColour = HUD.color;
        hudColour.a = 1.0f;
        HUD.color = hudColour;

        fadeCD = 5f;

        mechScreen.SetActive(false);
    }

    void Update()
    {

        fadeCD -= 1f * Time.deltaTime;

        if (fadeCD <= 0f)

        {
            //Color crosshairColour = mechCrosshair.color;
           // crosshairColour.a += 0.2f * Time.deltaTime;
            //mechCrosshair.color = crosshairColour;

           // Color weaponCrosshair_c = weaponCrosshair.color;
            //weaponCrosshair_c.a += 0.2f * Time.deltaTime;
            //weaponCrosshair.color = weaponCrosshair_c;

            Color hudColour = HUD.color;
            hudColour.a -= 0.2f * Time.deltaTime;
            HUD.color = hudColour;

            if (hudColour.a <= 0f)
            {
                objectHUD.SetActive(false);
            }
        }
    }

    public void RemoveScreen()
    {
        mechScreen.SetActive(false);
    }

    public void FadeHUD()
    {
        fadeOutHud = true;
    }

}
