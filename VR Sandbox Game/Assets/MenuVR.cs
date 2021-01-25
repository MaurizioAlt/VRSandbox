using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR.Extras;

public class MenuVR : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public GameObject mainMenu;
    public GameObject optionsMenu;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        
        if (e.target.name == "PlayButton")
        {
            Debug.Log("PlayButton was clicked");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (e.target.name == "OptionsButton")
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
            Debug.Log("Option Menu was clicked");
        }
        if (e.target.name == "QuitButton")
        {
            Application.Quit();
            Debug.Log("ExitButton was clicked");
        }
        if (e.target.name == "BackToMainMenu")
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "PlayButton")
        {
            Debug.Log("PlayButton was entered");
        }
        else if (e.target.name == "OptionsButton")
        {
            Debug.Log("Options Button was entered");
        }
        else if (e.target.name == "QuitButton")
        {
            Debug.Log("QuitButton was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "PlayButton")
        {
            Debug.Log("PlayButton was exited");
        }
        else if (e.target.name == "OptionsButton")
        {
            Debug.Log("Options Button was exited");
        }
        else if (e.target.name == "QuitButton")
        {
            Debug.Log("QuitButton was exited");
        }
    }
}
