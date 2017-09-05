using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechAimControl : MonoBehaviour {

    public GameObject crosshair;
    public bool followTarget;
    public GameObject targetPos;
    public GameObject playerMech, playerObject;

	// Use this for initialization
	void Start () {
        followTarget = false;
	}
	
	// Update is called once per frame
	void Update () {

        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Input.GetButtonDown ("B Button"))
        {
            followTarget = false;
            //crosshair.SetActive(false);
            playerMech.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = true;
        }

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            targetPos = interactionInfo.collider.gameObject;
          

            //Debug.Log("Found object - distance: " +interactionInfo.distance + tag);

            if (interactedObject.tag == "PracticeTarget")
            {
              Debug.Log("Found object - distance: " + interactionInfo.distance + interactionInfo.collider.tag);
                // Debug.DrawLine(transform.position, interactedObject.transform.position, Color.red);

                //if (Input.GetButtonDown("A Button"))
                //{
                   // crosshair.SetActive(true);
                   // followTarget = true;
               // }
            }
        }

        if(followTarget == true)
        {
            transform.LookAt(targetPos.transform.position);
            //playerObject.transform.eulerAngles = new Vector3(0, transform.rotation.y, 0);
            playerMech.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
        }
    }
}
