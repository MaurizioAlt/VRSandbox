using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangePosition : MonoBehaviour
{
    public GameObject menu;
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
                    showPositionMenu();
                }
            }
        }
    }
    public void showPositionMenu()
    {
        menu.SetActive(true);
    }

    public void increasePositionX()
    {
        selectedGameObject.transform.position += new Vector3(1, 0, 0);
    }
    public void increasePositionY()
    {
        selectedGameObject.transform.position += new Vector3(0, 1, 0);
    }
    public void increasePositionZ()
    {
        selectedGameObject.transform.position += new Vector3(0, 0, 1);
    }
    public void decreasePositionX()
    {
        selectedGameObject.transform.position += new Vector3(-1, 0, 0);
    }
    public void decreasePositionY()
    {
        selectedGameObject.transform.position += new Vector3(0, -1, 0);
    }
    public void decreasePositionZ()
    {
        selectedGameObject.transform.position += new Vector3(0, 0, -1);
    }

    public void ExitPositionChangeMenu()
    {
        menu.SetActive(false);
    }
}
