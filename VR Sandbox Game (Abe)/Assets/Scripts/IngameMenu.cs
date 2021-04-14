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
    public GameObject scaleButton;
    public AudioSource menuBleep;
    public GameObject allButton;
    public GameObject RotateButton;
    public GameObject RotateXButton;
    public GameObject RotateYButton;
    public GameObject RotateZButton;
    public GameObject copyPasteMenu;
    public GameObject copyButton;
    public GameObject pasteButton;

    public Material selectColor;
    private Material unselectColor;


    public GameObject musicPlus;
    public GameObject musicMinus;

    public GameObject sfxPlus;
    public GameObject sfxMinus;

    public SteamVR_Action_Boolean toggleMenu = null;
    private SteamVR_Behaviour_Pose m_Pose = null;
    private bool menuActive=false;

    private Spawner spawnerScript;
    private Teleporter teleporterScript;
    private ObjectScaling scalerScript;
    private Picker pickerScript;
    private RotateObject rotateScript;
    private GameSaveLoadManager gslManager;
    private CopyPaste copyPasteScript;

    // Start is called before the first frame update
    void Awake()
    {
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
        laserPointer.PointerClick += PointerClick;
        spawnerScript = GetComponent<Spawner>();
        teleporterScript = GetComponent<Teleporter>();
        scalerScript = GetComponent<ObjectScaling>();
        pickerScript = GetComponent<Picker>();
        rotateScript = GetComponent<RotateObject>();
        gslManager = GameObject.FindGameObjectWithTag("GameSaveLoadManager").GetComponent<GameSaveLoadManager>();
        copyPasteScript = this.GetComponent<CopyPaste>();
        unselectColor = RotateXButton.GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (toggleMenu.GetStateDown(m_Pose.inputSource) && !menuActive)
        {
            MenuSquare.SetActive(true);
            menuActive = true;
           
            menuBleep.Play();
        }
        else if (toggleMenu.GetStateDown(m_Pose.inputSource) && menuActive)
        {
            MenuSquare.SetActive(false);
            menuActive = false;
    
            menuBleep.Play();
        }

        if((SpawnMenu.activeSelf || SpawnMenu2.activeSelf) && menuActive && spawnerScript.deletingObject)
        {
            spawnerScript.deletingObject = true;
            spawnerScript.spawningObject = false;
            teleporterScript.canTeleport = false;
        }
        else if ((SpawnMenu.activeSelf || SpawnMenu2.activeSelf) && menuActive && !spawnerScript.deletingObject)
        {
            spawnerScript.deletingObject = false;
            spawnerScript.spawningObject = true;
            teleporterScript.canTeleport = false;
        }
        else
        {
            spawnerScript.spawningObject = false;
            teleporterScript.canTeleport = true;
            spawnerScript.deletingObject = false;
        }


        if (ColorPicker.activeSelf && menuActive)
        {
            pickerScript.pickingColor = true;
        }
        else
        {
            pickerScript.pickingColor = false;
        }

        if(lengthButton.activeSelf && scaleButton && menuActive)
        {
            scalerScript.isScaling = true;
        }
        else
        {
            scalerScript.isScaling = false;
        }

        if (RotateXButton.activeSelf)
        {
            rotateScript.canRotate = true;
        }
        else
        {
            rotateScript.canRotate = false;
        }

        if(EditMenu.activeSelf == false)
        {
            scalerScript.scalingAll = false;
            scalerScript.scalingHeight = false;
            scalerScript.scalingWidth = false;
            scalerScript.scalingLength = false;
            rotateScript.canRotate = false;

        }

        if(copyPasteMenu.activeSelf == false)
        {
            copyPasteScript.isCopyingObject = false;
            copyPasteScript.isPastingObject = false;
        }

        if (copyPasteMenu.activeSelf)
        {
            teleporterScript.canTeleport = false;
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
            menuBleep.Play();
        }

        if (e.target.name == "SpawnObjectButton")
        {
            ClearWindows();
            SpawnMenu.SetActive(true);
            menuBleep.Play();
        }

        if (e.target.name == "EditMenuButton")
        {
            ClearWindows();
            EditMenu.SetActive(true);
            scaleButton.SetActive(true);
            RotateButton.SetActive(true);
            menuBleep.Play();
        }


        // Main Menu
        if (e.target.name == "ChangeSceneButton")
        {
            ClearWindows();
            SceneMenu.SetActive(true);
            menuBleep.Play();
        }
        if (e.target.name == "SaveButton")
        {
            ClearWindows();
            SaveMenu.SetActive(true);
            menuBleep.Play();
        }
        if (e.target.name == "LoadButton")
        {
            ClearWindows();
            LoadMenu.SetActive(true);
            menuBleep.Play();
        }
        if (e.target.name == "SettingsButton")
        {
            ClearWindows();
            SettingsMenu.SetActive(true);
            menuBleep.Play();
        }
        if (e.target.name == "QuitButton")
        {
            ClearWindows();
            QuitMenu.SetActive(true);
            menuBleep.Play();
        }

        // Scene Menu
        if (e.target.name == "ForrestScene")
        {
            
            menuBleep.Play();
            SceneManager.LoadScene(2);
        }
        if (e.target.name == "DesertScene")
        {
           
            menuBleep.Play();
            SceneManager.LoadScene(1);
        }
        if (e.target.name == "SpaceScene")
        {
         
            menuBleep.Play();
            SceneManager.LoadScene(3);
        }


        // Save Menu
        if (e.target.name == "Save1")
        {
            menuBleep.Play();
            gslManager.Save("Save1");
        }
        if (e.target.name == "Save2")
        {
            menuBleep.Play();
            gslManager.Save("Save2");
        }
        if (e.target.name == "Save3")
        {
            menuBleep.Play();
            gslManager.Save("Save3");
        }
        if (e.target.name == "Save4")
        {
            menuBleep.Play();
            gslManager.Save("Save4");
        }


        // Load Menu
        if (e.target.name == "Load1")
        {
            menuBleep.Play();
            gslManager.Load("Save1");
        }
        if (e.target.name == "Load2")
        {
            menuBleep.Play();
            gslManager.Load("Save2");
        }
        if (e.target.name == "Load3")
        {
            menuBleep.Play();
            gslManager.Load("Save3");
        }
        if (e.target.name == "Load4")
        {
            menuBleep.Play();
            gslManager.Load("Save4");
        }


        // Settings Menu


        // Quit Menu
        if (e.target.name == "YesTitle")
        {
            SceneManager.LoadScene(0);
            //Application.Quit();
            menuBleep.Play();
        }
        if (e.target.name == "NoTitle")
        {
            ClearWindows();
            MainMenu.SetActive(true);
            menuBleep.Play();
        }



        // Spawn Menu
        if (e.target.name == "Duplicate Objects")
        {
            ClearWindows();
            copyPasteMenu.SetActive(true);
            copyButton.GetComponent<Renderer>().material = unselectColor;
            pasteButton.GetComponent<Renderer>().material = unselectColor;
            menuBleep.Play();
        }
        if (e.target.name == "Cube")
        {
   
            spawnerScript.objectToSpawn = 0;
            spawnerScript.deletingObject = false;
            spawnerScript.spawningObject = true;
            menuBleep.Play();
        }
        if (e.target.name == "Sphere")
        {
            spawnerScript.objectToSpawn = 1;
            spawnerScript.deletingObject = false;
            spawnerScript.spawningObject = true;
            menuBleep.Play();
        }
        if (e.target.name == "Capsule")
        {
           
            spawnerScript.objectToSpawn = 2;
            spawnerScript.deletingObject = false;
            spawnerScript.spawningObject = true;
            menuBleep.Play();
        }
        if (e.target.name == "Cylinder")
        {
            
            spawnerScript.objectToSpawn = 3;
            spawnerScript.deletingObject = false;
            spawnerScript.spawningObject = true;
            menuBleep.Play();
        }
        if (e.target.name == "Plane")
        {
            
            spawnerScript.objectToSpawn = 4;
            spawnerScript.deletingObject = false;
            spawnerScript.spawningObject = true;
            menuBleep.Play();
        }
        if (e.target.name == "Cone")
        {

            spawnerScript.objectToSpawn = 5;
            spawnerScript.deletingObject = false;
            spawnerScript.spawningObject = true;
            menuBleep.Play();
        }
        if (e.target.name == "Triangular Prism")
        {

            spawnerScript.objectToSpawn = 6;
            spawnerScript.deletingObject = false;
            spawnerScript.spawningObject = true;
            menuBleep.Play();
            Debug.Log("Triangular prism");

        }
        if (e.target.name == "DeleteButton")
        {
            
            spawnerScript.deletingObject = true;
            spawnerScript.spawningObject = false;
            menuBleep.Play();
        }
        if (e.target.name == "NextButton1")
        {
            ClearWindows();
            SpawnMenu2.SetActive(true);
            menuBleep.Play();
        }
        if (e.target.name == "PrevButton2")
        {
            ClearWindows();
            SpawnMenu.SetActive(true);
            menuBleep.Play();
        }

        //Copy/Paste Menu
        if (e.target.name == "Spawn Premades")
        {
            ClearWindows();
            copyPasteMenu.SetActive(false);
            SpawnMenu.SetActive(true);
            menuBleep.Play();
        }
        if (e.target.name == "CopyButton")
        {
            copyPasteScript.isCopyingObject = true;
            copyPasteScript.isPastingObject = false;

            copyButton.GetComponent<Renderer>().material = selectColor;
            pasteButton.GetComponent<Renderer>().material = unselectColor;
            menuBleep.Play();
        }
        if (e.target.name == "PasteButton")
        {
            copyPasteScript.isCopyingObject = false;
            copyPasteScript.isPastingObject = true;
            copyButton.GetComponent<Renderer>().material = unselectColor;
            pasteButton.GetComponent<Renderer>().material = selectColor;
            menuBleep.Play();
        }


        //Edit Menu

        if (e.target.name == "ColorButton")
        {
            
            ColorPicker.SetActive(true);
            lengthButton.SetActive(false);
            widthButton.SetActive(false);
            heightButton.SetActive(false);
            allButton.SetActive(false);
            RotateXButton.SetActive(false);
            RotateYButton.SetActive(false);
            RotateZButton.SetActive(false);
            menuBleep.Play();
        }
        if (e.target.name == "ScaleButton")
        {
            ColorPicker.SetActive(false);
            lengthButton.SetActive(true);
            widthButton.SetActive(true);
            heightButton.SetActive(true);
            allButton.SetActive(true);
            RotateXButton.SetActive(false);
            RotateYButton.SetActive(false);
            RotateZButton.SetActive(false);
            menuBleep.Play();

            lengthButton.GetComponent<Renderer>().material = unselectColor;
            widthButton.GetComponent<Renderer>().material = unselectColor;
            heightButton.GetComponent<Renderer>().material = unselectColor;

        }
        if (e.target.name == "RotateButton")
        {
            ColorPicker.SetActive(false);
            lengthButton.SetActive(false);
            widthButton.SetActive(false);
            heightButton.SetActive(false);
            allButton.SetActive(false);
            RotateXButton.SetActive(true);
            RotateYButton.SetActive(true);
            RotateZButton.SetActive(true);
            menuBleep.Play();

            RotateXButton.GetComponent<Renderer>().material = unselectColor;
            RotateYButton.GetComponent<Renderer>().material = unselectColor;
            RotateZButton.GetComponent<Renderer>().material = unselectColor;
        }

        //Scale Options
        if (e.target.name == "WidthButton")
        {
            scalerScript.isScaling = true;
            scalerScript.scalingWidth = true;
            scalerScript.scalingLength = false;
            scalerScript.scalingHeight = false;
            menuBleep.Play();
            lengthButton.GetComponent<Renderer>().material = unselectColor;
            widthButton.GetComponent<Renderer>().material = selectColor;
            heightButton.GetComponent<Renderer>().material = unselectColor;
            allButton.GetComponent<Renderer>().material = unselectColor;
        }
        if (e.target.name == "HeightButton")
        {
            scalerScript.isScaling = true;
            scalerScript.scalingHeight = true;
            scalerScript.scalingWidth = false;
            scalerScript.scalingLength = false;
            menuBleep.Play();
            lengthButton.GetComponent<Renderer>().material = unselectColor;
            widthButton.GetComponent<Renderer>().material = unselectColor;
            heightButton.GetComponent<Renderer>().material = selectColor;
            allButton.GetComponent<Renderer>().material = unselectColor;
        }
        if (e.target.name == "LengthButton")
        {
            scalerScript.isScaling = true;
            scalerScript.scalingLength = true;
            scalerScript.scalingHeight = false;
            scalerScript.scalingWidth = false;
            menuBleep.Play();

            lengthButton.GetComponent<Renderer>().material = selectColor;
            widthButton.GetComponent<Renderer>().material = unselectColor;
            heightButton.GetComponent<Renderer>().material = unselectColor;
            allButton.GetComponent<Renderer>().material = unselectColor;
        }
        if(e.target.name == "AllButton")
        {
            scalerScript.scalingAll = true;
            scalerScript.scalingLength = false;
            scalerScript.scalingHeight = false;
            scalerScript.scalingWidth = false;
            menuBleep.Play();
            lengthButton.GetComponent<Renderer>().material = unselectColor;
            widthButton.GetComponent<Renderer>().material = unselectColor;
            heightButton.GetComponent<Renderer>().material = unselectColor;
            allButton.GetComponent<Renderer>().material = selectColor;
        }

        if (e.target.name == "RotateX")
        {
            rotateScript.rotatingX = true;
            rotateScript.rotatingY = false;
            rotateScript.rotatingZ = false;

            RotateXButton.GetComponent<Renderer>().material = selectColor;
            RotateYButton.GetComponent<Renderer>().material = unselectColor;
            RotateZButton.GetComponent<Renderer>().material = unselectColor;
            menuBleep.Play();
        }
        if (e.target.name == "RotateY")
        {
            rotateScript.rotatingX = false;
            rotateScript.rotatingY = true;
            rotateScript.rotatingZ = false;
            menuBleep.Play();

            RotateXButton.GetComponent<Renderer>().material = unselectColor;
            RotateYButton.GetComponent<Renderer>().material = selectColor;
            RotateZButton.GetComponent<Renderer>().material = unselectColor;
        }
        if (e.target.name == "RotateZ")
        {
            rotateScript.rotatingX = false;
            rotateScript.rotatingY = false;
            rotateScript.rotatingZ = true;
            menuBleep.Play();

            RotateXButton.GetComponent<Renderer>().material = unselectColor;
            RotateYButton.GetComponent<Renderer>().material = unselectColor;
            RotateZButton.GetComponent<Renderer>().material = selectColor;
        }

        if (e.target.name == "MusicPlus")
        {
            if (VolumeScript.musicVolumeInt < 100)
            {
                VolumeScript.musicVolumeInt += 5;
                VolumeScript.musicVolume += .05f;
            }
            menuBleep.Play();
        }
        if (e.target.name == "MusicMinus")
        {
            if ( VolumeScript.musicVolumeInt > 0)
            {
                VolumeScript.musicVolumeInt -= 5;
                VolumeScript.musicVolume -= .05f;
            }
            menuBleep.Play();
        }
        if (e.target.name == "SFXPlus")
        {
            if (VolumeScript.sfxVolumeInt < 100)
            {
                VolumeScript.sfxVolumeInt += 5;
                VolumeScript.sfxVolume += .05f;
            }
            menuBleep.Play();
        }
        if (e.target.name == "SFXMinus")
        {
            if (VolumeScript.sfxVolumeInt > 0)
            {
                VolumeScript.sfxVolume -= .05f;
                VolumeScript.sfxVolumeInt -= 5;
            }
            menuBleep.Play();
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
        copyPasteMenu.SetActive(false);

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
