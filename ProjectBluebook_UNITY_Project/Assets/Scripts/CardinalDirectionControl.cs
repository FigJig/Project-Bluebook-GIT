using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class CardinalDirectionControl : MonoBehaviour
    {
       // public MouseLook mouseLook;
        public GameObject mech;
        public float xOffsetSpeed;
        Renderer cardinalMaterial;

        // Use this for initialization
        void Start()
        {
            cardinalMaterial = GetComponent<Renderer>();      
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log("Rot value:" + mech.transform.localRotation.y);
            xOffsetSpeed = mech.transform.eulerAngles.y / 360;
            Vector2 currentOffset = new Vector2(xOffsetSpeed, 0);
            cardinalMaterial.material.mainTextureOffset = currentOffset;
        }
    }
}
