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
    public GameObject LoadMenu;
    public GameObject PlayMenu;

    public GameObject PlayButton;
    public GameObject LoadButton;
    public GameObject SettingsButton;
    public GameObject QuitButton;
    
    public GameObject SettingsBackButton;
    public GameObject LoadBackButton;
    public GameObject PlayBackButton;


    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public GameObject Slot4;

    public GameObject Default;
    public GameObject Forest;
    public GameObject Space;
    public AudioSource menuBleep;

    public Color32 baseColor;
    public Color32 hoverColor;
    public Color32 clickColor;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        // Main Menu
        if (e.target.name == "PlayButton")
        {
            PlayButton.GetComponent<Image>().color = clickColor;
            ClearMenus();
            PlayMenu.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            menuBleep.Play();
        }
        if (e.target.name == "LoadButton")
        {
            LoadButton.GetComponent<Image>().color = clickColor;
            ClearMenus();
            LoadMenu.SetActive(true);
            menuBleep.Play();
        }
        if (e.target.name == "SettingsButton")
        {
            SettingsButton.GetComponent<Image>().color = clickColor;
            ClearMenus();
            SettingsMenu.SetActive(true);
            menuBleep.Play();
        }
        if (e.target.name == "QuitButton")
        {
            QuitButton.GetComponent<Image>().color = clickColor;
            Application.Quit();
            menuBleep.Play();
        }
        
        // Back Button
        if (e.target.name == "SettingsBackButton")
        {
            SettingsBackButton.GetComponent<Image>().color = clickColor;
            ClearMenus();
            MainMenu.SetActive(true);
            menuBleep.Play();
        }
        if (e.target.name == "LoadBackButton")
        {
            LoadBackButton.GetComponent<Image>().color = clickColor;
            ClearMenus();
            MainMenu.SetActive(true);
            menuBleep.Play();
        }
        if (e.target.name == "PlayBackButton")
        {
            PlayBackButton.GetComponent<Image>().color = clickColor;
            ClearMenus();
            MainMenu.SetActive(true);
            menuBleep.Play();
        }


        // Load Menu
        if (e.target.name == "Slot1")
        {
            Slot1.GetComponent<Image>().color = clickColor;
            menuBleep.Play();
        }
        if (e.target.name == "Slot2")
        {
            Slot2.GetComponent<Image>().color = clickColor;
            menuBleep.Play();
        }
        if (e.target.name == "Slot3")
        {
            Slot3.GetComponent<Image>().color = clickColor;
            menuBleep.Play();
        }
        if (e.target.name == "Slot4")
        {
            Slot4.GetComponent<Image>().color = clickColor;
            menuBleep.Play();
        }

        // Play Menu
        if (e.target.name == "DefaultScene")
        {
            Default.GetComponent<Image>().color = clickColor;
            SceneManager.LoadScene(1);
            menuBleep.Play();
        }
        if (e.target.name == "ForestScene")
        {
            Forest.GetComponent<Image>().color = clickColor;
            SceneManager.LoadScene(2);
            menuBleep.Play();
        }
        if (e.target.name == "SpaceScene")
        {
            Space.GetComponent<Image>().color = clickColor;
            SceneManager.LoadScene(3);
            menuBleep.Play();
        }

    }


    public void PointerInside(object sender, PointerEventArgs e)
    {
        /*if (e.target.CompareTag("Button"))
        {
            this.GetComponent<Image>().color = hoverColor;
        }*/
        // Main Menu
        if (e.target.name == "PlayButton")
        {
            PlayButton.GetComponent<Image>().color = hoverColor;
        }
        if (e.target.name == "LoadButton")
        {
            LoadButton.GetComponent<Image>().color = hoverColor;
        }
        if (e.target.name == "SettingsButton")
        {
            SettingsButton.GetComponent<Image>().color = hoverColor;
        }
        if (e.target.name == "QuitButton")
        {
            QuitButton.GetComponent<Image>().color = hoverColor;
        }

        // Back
        if (e.target.name == "SettingsBackButton")
        {
            SettingsBackButton.GetComponent<Image>().color = hoverColor;            
        }
        if (e.target.name == "LoadBackButton")
        {
            LoadBackButton.GetComponent<Image>().color = hoverColor;
        }
        if (e.target.name == "PlayBackButton")
        {
            PlayBackButton.GetComponent<Image>().color = hoverColor;
        }

        // Load Menu
        if (e.target.name == "Slot1")
        {
            Slot1.GetComponent<Image>().color = hoverColor;
        }
        if (e.target.name == "Slot2")
        {
            Slot2.GetComponent<Image>().color = hoverColor;
        }
        if (e.target.name == "Slot3")
        {
            Slot3.GetComponent<Image>().color = hoverColor;
        }
        if (e.target.name == "Slot4")
        {
            Slot4.GetComponent<Image>().color = hoverColor;
        }

        // Play Menu
        if (e.target.name == "DefaultScene")
        {
            Default.GetComponent<Image>().color = hoverColor;
        }
        if (e.target.name == "ForestScene")
        {
            Forest.GetComponent<Image>().color = hoverColor;
        }
        if (e.target.name == "SpaceScene")
        {
            Space.GetComponent<Image>().color = hoverColor;
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        /*if (e.target.CompareTag("Button"))
        {
            this.GetComponent<Image>().color = baseColor;
        }*/
        // Main Menu
        if (e.target.name == "PlayButton")
        {
            PlayButton.GetComponent<Image>().color = baseColor;
        }
        if (e.target.name == "LoadButton")
        {
            LoadButton.GetComponent<Image>().color = baseColor;
        }
        if (e.target.name == "SettingsButton")
        {
            SettingsButton.GetComponent<Image>().color = baseColor;
        }
        if (e.target.name == "QuitButton")
        {
            QuitButton.GetComponent<Image>().color = baseColor;
        }

        // Back Button
        if (e.target.name == "SettingsBackButton")
        {
            SettingsBackButton.GetComponent<Image>().color = baseColor;
        }
        if (e.target.name == "LoadBackButton")
        {
            LoadBackButton.GetComponent<Image>().color = baseColor;
        }
        if (e.target.name == "PlayBackButton")
        {
            PlayBackButton.GetComponent<Image>().color = baseColor;
        }

        // Load Menu
        if (e.target.name == "Slot1")
        {
            Slot1.GetComponent<Image>().color = baseColor;
        }
        if (e.target.name == "Slot2")
        {
            Slot2.GetComponent<Image>().color = baseColor;
        }
        if (e.target.name == "Slot3")
        {
            Slot3.GetComponent<Image>().color = baseColor;
        }
        if (e.target.name == "Slot4")
        {
            Slot4.GetComponent<Image>().color = baseColor;
        }

        // Play Menu
        if (e.target.name == "DefaultScene")
        {
            Default.GetComponent<Image>().color = baseColor;
        }
        if (e.target.name == "ForestScene")
        {
            Forest.GetComponent<Image>().color = baseColor;
        }
        if (e.target.name == "SpaceScene")
        {
            Space.GetComponent<Image>().color = baseColor;
        }
    }

    public void ClearMenus()
    {
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        LoadMenu.SetActive(false);
        PlayMenu.SetActive(false);
    }
}
