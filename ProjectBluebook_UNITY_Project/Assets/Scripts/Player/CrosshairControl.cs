using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class CrosshairControl : MonoBehaviour
{
    public bool targetLocked;

    public GameObject crosshair, interactedObject, projectile;
    //public Vector2 currentTarget;
    private RectTransform rt;
    private Vector2 pos;
    public Text distanceText;
    public AudioClip targetLockedAudio;

    public float x_speed;
    public float y_speed;

    AudioSource crosshairAS;

    // Use this for initialization
    void Start()
    {
        targetLocked = false;
        rt = GetComponent<RectTransform>();
        projectile.gameObject.GetComponent<ProjectileControl>().currentTarget = null;
        projectile.gameObject.GetComponent<ProjectileControl>().targetLocked = false;
        crosshairAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = GetInput();

        Vector3 clampedPosition = transform.position;

        if (targetLocked == false)
        {
            float horizontalMovement = input.x * x_speed;
            float verticalMovement = input.y * y_speed;
            horizontalMovement *= Time.deltaTime;
            verticalMovement *= Time.deltaTime;

            crosshair.transform.Translate(horizontalMovement, verticalMovement, 0);
        }

        //540.y = middle. 960.x = middle.
        clampedPosition.y = Mathf.Clamp(transform.position.y, 390f, 690f);
        clampedPosition.x = Mathf.Clamp(transform.position.x, 810f, 1110f);
        transform.position = clampedPosition;

        RaycastHit interactionInfo;
        Ray interactionRay = Camera.main.ScreenPointToRay(crosshair.transform.position);

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            distanceText.gameObject.GetComponent<Text>().text = ((int)interactionInfo.distance).ToString() + "m";
            interactedObject = interactionInfo.collider.gameObject;

            if (interactedObject.tag == "Enemy")
            {
                Debug.Log("Found object - distance: " + interactionInfo.distance + interactedObject.tag);

                if (Input.GetButtonDown("A Button") & targetLocked == false)
                {
                    GameObject enemyObject = interactedObject;
                    enemyObject = interactionInfo.collider.gameObject;
                    pos = RectTransformUtility.WorldToScreenPoint(Camera.main, enemyObject.transform.position);
                    rt.position = pos;
                    Debug.Log("LOCKED ON");
                    targetLocked = true;
                    projectile.gameObject.GetComponent<ProjectileControl>().currentTarget = enemyObject;
                    projectile.gameObject.GetComponent<ProjectileControl>().targetLocked = true;

                    crosshairAS.clip = targetLockedAudio;
                    crosshairAS.PlayOneShot(crosshairAS.clip);
                }
            }

            if (interactedObject.tag == "WeakPoint")
            {
                Debug.Log("Found object - distance: " + interactionInfo.distance + interactedObject.tag);

                if (Input.GetButtonDown("A Button") & targetLocked == false)
                {
                    GameObject weakPointObject = interactedObject;
                    weakPointObject = interactionInfo.collider.gameObject;
                    pos = RectTransformUtility.WorldToScreenPoint(Camera.main, weakPointObject.transform.position);
                    rt.position = pos;
                    Debug.Log("LOCKED ON");
                    targetLocked = true;
                    projectile.gameObject.GetComponent<ProjectileControl>().currentTarget = weakPointObject;
                    projectile.gameObject.GetComponent<ProjectileControl>().targetLocked = true;

                    crosshairAS.clip = targetLockedAudio;
                    crosshairAS.PlayOneShot(crosshairAS.clip);
                }
            }
        }

        if (Input.GetButtonDown("Start Button"))
        {
            projectile.gameObject.GetComponent<ProjectileControl>().targetLocked = false;
            projectile.gameObject.GetComponent<ProjectileControl>().currentTarget = null;
            targetLocked = false;
        }

        if (targetLocked)
        {
            pos = RectTransformUtility.WorldToScreenPoint(Camera.main, interactedObject.transform.position);
            rt.position = pos;
        }

        if (transform.position.y > 691f)
        {
            rt.position = new Vector2(960, 540);
            targetLocked = false;
            projectile.gameObject.GetComponent<ProjectileControl>().targetLocked = false;
            projectile.gameObject.GetComponent<ProjectileControl>().currentTarget = null;
        }

        if (transform.position.y < 389f)
        {
            rt.position = new Vector2(960, 540);
            targetLocked = false;
            projectile.gameObject.GetComponent<ProjectileControl>().targetLocked = false;
            projectile.gameObject.GetComponent<ProjectileControl>().currentTarget = null;
        }

        if (transform.position.x > 1111f)
        {
            rt.position = new Vector2(960, 540);
            targetLocked = false;
            projectile.gameObject.GetComponent<ProjectileControl>().targetLocked = false;
            projectile.gameObject.GetComponent<ProjectileControl>().currentTarget = null;
        }

        if (transform.position.x < 810f)
        {
            rt.position = new Vector2(960, 540);
            targetLocked = false;
            projectile.gameObject.GetComponent<ProjectileControl>().targetLocked = false;
            projectile.gameObject.GetComponent<ProjectileControl>().currentTarget = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
       // if (other.gameObject.tag == "MechCrosshair")
       // {
         //   transform.position = other.transform.position;
         //   Debug.Log("Weapon crosshair locked on");
       // }
    }

    private Vector2 GetInput()
    {

        Vector2 input = new Vector2
        {
            x = CrossPlatformInputManager.GetAxis("LeftJoystickHorizontal"),
            y = CrossPlatformInputManager.GetAxis("LeftJoystickVertical")
        };

        return input;
    }
}

//Ray interactionRay = new Ray (transform.position, Vector3.forward);
//RaycastHit interactionInfo;

//if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
//{
//GameObject interactedObject = interactionInfo.collider.gameObject;

//Debug.Log("Found object - distance: " + interactionInfo.distance + tag);
//Debug.DrawLine(transform.position, Vector3.forward, Color.red);

//if (interactedObject.tag == "Enemy")
//{
//  Debug.Log("Weapon found enemy - distance: " + interactionInfo.distance + interactedObject.tag);
//}
//}
