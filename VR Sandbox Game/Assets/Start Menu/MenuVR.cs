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
    public GameObject MainMenu;
    public GameObject SettingsMenu;

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
        if (e.target.name == "SettingsButton")
        {
            MainMenu.SetActive(false);
            SettingsMenu.SetActive(true);
            Debug.Log("Settings Menu was clicked");
        }
        if (e.target.name == "QuitButton")
        {
            Application.Quit();
            Debug.Log("ExitButton was clicked");
        }
        if (e.target.name == "BackToMainMenu")
        {
            MainMenu.SetActive(true);
            SettingsMenu.SetActive(false);
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "PlayButton")
        {
            Debug.Log("PlayButton was entered");
        }
        else if (e.target.name == "SettingsButton")
        {
            Debug.Log("Settings Button was entered");
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
        else if (e.target.name == "SettingsButton")
        {
            Debug.Log("Settings Button was exited");
        }
        else if (e.target.name == "QuitButton")
        {
            Debug.Log("QuitButton was exited");
        }
    }
}
