using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour {

    public AudioSource bgm;
    public float loadCooldown;
    public bool startGame;

    public GameObject buttons, credits, monitor;

    void Start()
    {
        bgm.GetComponent<AudioSource>();
        startGame = false;
    }
    
    void Update()
    {

        if (startGame == true)
        {
            Cursor.visible = false;
            loadCooldown -= 1f * Time.deltaTime;
            bgm.GetComponent<AudioSource>().volume -= 0.1f * Time.deltaTime;

            if (loadCooldown <= 0f)
            {
                SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
            }
        }

        if (Input.GetButtonDown("A Button"))
        {
            startGame = true;
            buttons.gameObject.GetComponent<Animator>().Play("MenuButtonsAnim");
            monitor.gameObject.GetComponent<Animator>().Play("Monitor_anim_menu");
        }

        if (Input.GetButtonDown("X Button"))
        {
            credits.SetActive(true);
        }

        if (Input.GetButtonDown("Y Button"))
        {
            credits.SetActive(false);
        }

        if (Input.GetButtonDown("B Button") & credits.activeSelf == false)
        {
            Debug.Log("Game exited");
            Application.Quit();
        }
    }

    public void LoadScene()
    {
        startGame = true;
        buttons.gameObject.GetComponent<Animator>().Play("MenuButtonsAnim");
        //SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
       // bgm.GetComponent<AudioSource>().volume -= 0.1f;
    }

    public void ExitGame ()
    {
        Application.Quit();
        Debug.Log("Game exited");
    }

    public void ShowCredits(GameObject creditsOverlay)
    {
        creditsOverlay.SetActive(true);
    }

    public void HideCredits(GameObject creditsOverlay)
    {
        creditsOverlay.SetActive(false);
    }
}
