using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EditMenu : MonoBehaviour
{
    public GameObject editmenu;
    public GameObject colormenu;
    public GameObject positionmenu;
    public GameObject rotatemenu;
    public GameObject resizemenu;
    public GameObject sliderpositionmenu;
    public GameObject sliderrotatemenu;

    public static GameObject selectedGameObject;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // check if clicked on an object directly
            if (Physics.Raycast(ray, out hit, 100) && !EventSystem.current.IsPointerOverGameObject())
            {
                // Debug.Log( hit.transform.gameObject.name );
                // if clicked on one of the prefab objects, set the current object to the most recent clicked one
                if (ObjectList.objects.Contains(hit.transform.gameObject.name))
                {
                    selectedGameObject = hit.transform.gameObject;
                    Debug.Log("Hooray" + selectedGameObject.name);
                }

                if(!colormenu.activeInHierarchy && !positionmenu.activeInHierarchy && !rotatemenu.activeInHierarchy && !resizemenu.activeInHierarchy 
                    && !sliderpositionmenu.activeInHierarchy && !sliderrotatemenu.activeInHierarchy)
                    EnterEditMenu();
            }
        }
    }

    public void despawn()
    {
        Destroy(selectedGameObject);
    }

    public void EnterEditMenu()
    {
        editmenu.SetActive(true);
    }

    public void ExitEditMenu()
    {
        editmenu.SetActive(false);
    }

    public void SwitchEditToColor()
    {
        editmenu.SetActive(false);
        colormenu.SetActive(true);
    }

    public void SwitchColorToEdit()
    {
        editmenu.SetActive(true);
        colormenu.SetActive(false);
    }

    public void SwitchEditToPosition()
    {
        editmenu.SetActive(false);
        positionmenu.SetActive(true);
    }

    public void SwitchPositionToEdit()
    {
        editmenu.SetActive(true);
        positionmenu.SetActive(false);
    }

    public void SwitchEditToRotate()
    {
        editmenu.SetActive(false);
        rotatemenu.SetActive(true);
    }

    public void SwitchRotateToEdit()
    {
        editmenu.SetActive(true);
        rotatemenu.SetActive(false);
    }

    public void SwitchEditToSliderPosition()
    {
        editmenu.SetActive(false);
        sliderpositionmenu.SetActive(true);
    }

    public void SwitchSliderPositionToEdit()
    {
        editmenu.SetActive(true);
        sliderpositionmenu.SetActive(false);
    }

    public void SwitchEditToSliderRotate()
    {
        editmenu.SetActive(false);
        sliderrotatemenu.SetActive(true);
    }

    public void SwitchSliderRotateToEdit()
    {
        editmenu.SetActive(true);
        sliderrotatemenu.SetActive(false);
    }

    public void SwitchEditToSize()
    {
        editmenu.SetActive(false);
        resizemenu.SetActive(true);
    }

    public void SwitchSizeToEdit()
    {
        editmenu.SetActive(true);
        resizemenu.SetActive(false);
    }
}
