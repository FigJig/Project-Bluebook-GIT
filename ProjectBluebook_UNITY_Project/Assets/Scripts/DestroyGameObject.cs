using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour {

    public GameObject mainBGM;

	public void Destroy()
    {
        mainBGM.SetActive(true);
        Destroy(gameObject);
    }
}
