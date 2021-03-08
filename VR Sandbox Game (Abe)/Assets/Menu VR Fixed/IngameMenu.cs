using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR;

public class IngameMenu : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    public GameObject MainMenu;
    public GameObject SceneMenu;
    public GameObject SaveMenu;
    public GameObject LoadMenu;
    public GameObject SettingsMenu;
    public GameObject QuitMenu;
    public GameObject SpawnMenu;
    public GameObject SpawnMenu2;
    public GameObject EditMenu;
    public GameObject Background;
    public GameObject ColorPicker;
    public GameObject MenuSquare;
    public GameObject lengthButton;
    public GameObject widthButton;
    public GameObject heightButton;

    public SteamVR_Action_Boolean toggleMenu = null;
    private SteamVR_Behaviour_Pose m_Pose = null;
    private bool menuActive=false;

    private Spawner spawnerScript;
    private Teleporter teleporterScript;

    // Start is called before the first frame update
    void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        laserPointer.PointerClick += PointerClick;
        spawnerScript = GetComponent<Spawner>();
        teleporterScript = GetComponent<Teleporter>();
    }

    private void Update()
    {
        if (toggleMenu.GetStateDown(m_Pose.inputSource) && !menuActive)
        {
            MenuSquare.SetActive(true);
            menuActive = true;
            Debug.Log("pickup");
        }
        else if (toggleMenu.GetStateDown(m_Pose.inputSource) && menuActive)
        {
            MenuSquare.SetActive(false);
            menuActive = false;
            Debug.Log("pickup");
        }

        if (SpawnMenu.activeSelf && menuActive)
        {
            spawnerScript.spawningObject = true;
            teleporterScript.canTeleport = false;
        }
        else
        {
            spawnerScript.spawningObject = false;
            teleporterScript.canTeleport = true;
        }

    }


    // Update is called once per frame
    public void PointerClick(object sender, PointerEventArgs e)
    {

        // Menu Bar
        if (e.target.name == "MainMenuButton")
        {
            ClearWindows();
            MainMenu.SetActive(true);
        }

        if (e.target.name == "SpawnObjectButton")
        {
            ClearWindows();
            SpawnMenu.SetActive(true);
        }

        if (e.target.name == "EditMenuButton")
        {
            ClearWindows();
            EditMenu.SetActive(true);
        }


        // Main Menu
        if (e.target.name == "ChangeSceneButton")
        {
            ClearWindows();
            SceneMenu.SetActive(true);
        }
        if (e.target.name == "SaveButton")
        {
            ClearWindows();
            SaveMenu.SetActive(true);
        }
        if (e.target.name == "LoadButton")
        {
            ClearWindows();
            LoadMenu.SetActive(true);
        }
        if (e.target.name == "SettingsButton")
        {
            ClearWindows();
            SettingsMenu.SetActive(true);
        }
        if (e.target.name == "QuitButton")
        {
            ClearWindows();
            QuitMenu.SetActive(true);
        }

        // Scene Menu
        if (e.target.name == "ForrestScene")
        {
            Debug.Log("ForrestScene was clicked");
        }
        if (e.target.name == "DesertScene")
        {
            Debug.Log("DesertScene was clicked");
        }
        if (e.target.name == "SpaceScene")
        {
            Debug.Log("SpaceScene was clicked");
        }


        // Save Menu
        if (e.target.name == "Save1")
        {
            Debug.Log("Save1 was clicked");
        }
        if (e.target.name == "Save2")
        {
            Debug.Log("Save2 was clicked");
        }
        if (e.target.name == "Save3")
        {
            Debug.Log("Save3 was clicked");
        }
        if (e.target.name == "Save4")
        {
            Debug.Log("Save4 was clicked");
        }


        // Load Menu
        if (e.target.name == "Load1")
        {
            Debug.Log("Load1 was clicked");
        }
        if (e.target.name == "Load2")
        {
            Debug.Log("Load2 was clicked");
        }
        if (e.target.name == "Load3")
        {
            Debug.Log("Load3 was clicked");
        }
        if (e.target.name == "Load4")
        {
            Debug.Log("Load4 was clicked");
        }


        // Settings Menu


        // Quit Menu
        if (e.target.name == "YesTitle")
        {
            SceneManager.LoadScene(0);
            //Application.Quit();
        }
        if (e.target.name == "NoTitle")
        {
            ClearWindows();
            MainMenu.SetActive(true);
        }



        // Spawn Menu
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was clicked");
            spawnerScript.objectToSpawn = 0;
        }
        if (e.target.name == "Sphere")
        {
            Debug.Log("Sphere was clicked");
            spawnerScript.objectToSpawn = 1;
        }
        if (e.target.name == "Capsule")
        {
            Debug.Log("Capsule was clicked");
            spawnerScript.objectToSpawn = 2;
        }
        if (e.target.name == "Cylinder")
        {
            Debug.Log("Cylinder was clicked");
            spawnerScript.objectToSpawn = 3;
        }
        if (e.target.name == "DeleteButton")
        {
            Debug.Log("DeleteButton was clicked");
            spawnerScript.deletingObject = true;
        }
        if (e.target.name == "NextButton1")
        {
            ClearWindows();
            SpawnMenu2.SetActive(true);
        }
        if (e.target.name == "PrevButton2")
        {
            ClearWindows();
            SpawnMenu.SetActive(true);
        }

        //Edit Menu

        if (e.target.name == "ColorButton")
        {
            Debug.Log("colorbutton was clicked");
            ColorPicker.SetActive(true);
            lengthButton.SetActive(false);
            widthButton.SetActive(false);
            heightButton.SetActive(false);
        }
        if (e.target.name == "ScaleButton")
        {
            ColorPicker.SetActive(false);
            lengthButton.SetActive(true);
            widthButton.SetActive(true);
            heightButton.SetActive(true);

        }

    }

    public void ClearWindows()
    {
        MainMenu.SetActive(false);
        SceneMenu.SetActive(false);
        SaveMenu.SetActive(false);
        LoadMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        QuitMenu.SetActive(false);
        SpawnMenu.SetActive(false);
        SpawnMenu2.SetActive(false);
        EditMenu.SetActive(false);
        //ColorPicker.SetActive(false);

    }
    /*public void ChangeScene()
    {
        SceneMenu.SetActive(true);

        if (e.target.name == "ForrestScene")
        {
            Debug.Log("ForrestScene was clicked");
        }
        else if (e.target.name == "DesertScene")
        {
            Debug.Log("DesertScene was clicked");
        }
        else if (e.target.name == "SpaceScene")
        {
            Debug.Log("SpaceScene was clicked");
        }
    }
    
    public void Save()
    {
        SaveMenu.SetActive(true);

        if (e.target.name == "Save1")
        {
            Debug.Log("Save1 was clicked");
        }
        else if (e.target.name == "Save2")
        {
            Debug.Log("Save2 was clicked");
        }
        else if (e.target.name == "Save3")
        {
            Debug.Log("Save3 was clicked");
        }
        else if (e.target.name == "Save4")
        {
            Debug.Log("Save4 was clicked");
        }
    }

    public void Load()
    {
        LoadMenu.SetActive(true);

        if (e.target.name == "Load1")
        {
            Debug.Log("Load1 was clicked");
        }
        else if (e.target.name == "Load2")
        {
            Debug.Log("Load2 was clicked");
        }
        else if (e.target.name == "Load3")
        {
            Debug.Log("Load3 was clicked");
        }
        else if (e.target.name == "Load4")
        {
            Debug.Log("Load4 was clicked");
        }

    }
    public void Quit()
    {
        QuitMenu.SetActive(true);

        if (e.target.name == "YesTitle")
        {
            Application.Quit();
        }
        else if (e.target.name == "NoTitle")
        {
            ClearWindows();
            MainMenu.SetActive(true);
        }
    }
    public void Spawn()
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was clicked");

        }
        else if (e.target.name == "Sphere")
        {
            Debug.Log("Sphere was clicked");

        }
        else if (e.target.name == "Capsule")
        {
            Debug.Log("Capsule was clicked");

        }
        else if (e.target.name == "Cylinder")
        {
            Debug.Log("Cylinder was clicked");

        }
        else if (e.target.name == "DeleteButton")
        {
            Debug.Log("DeleteButton was clicked");
        }

        if (e.target.name == "NextButton1")
        {
            ClearWindows();
            SpawnMenu2.SetActive(true);
        }
        else if (e.target.name == "PrevButton2")
        {
            ClearWindows();
            SpawnMenu.SetActive(true);
        }
    }
    public void EditObject()
    {
        if (e.target.name == "ScaleObjectButton")
        {
            Debug.Log("ScaleObjectButton was clicked");
        }
        if (e.target.name == "ColorObjectButton")
        {
            Debug.Log("ColorObjectButton was clicked");
            // show color wheel, have code to manupulate object color
        }
    }*/
}
