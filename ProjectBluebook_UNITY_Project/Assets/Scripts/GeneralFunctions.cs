using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralFunctions : MonoBehaviour {

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //In-game Menu
        }

        //if (Input.GetKeyDown(KeyCode.W))
       // {
           //Dial setting; power suit or refresh UI
       // }
    }

}
