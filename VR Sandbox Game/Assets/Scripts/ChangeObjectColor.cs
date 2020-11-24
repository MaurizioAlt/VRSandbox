using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeObjectColor : MonoBehaviour
{
    public GameObject menu;
    public GameObject menu2;
    public static GameObject selectedGameObject;
    public Color[] colors;
    void Update()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            RaycastHit hit;
            
            // check if clicked on an object directly
            if( Physics.Raycast(ray, out hit, 100) && !EventSystem.current.IsPointerOverGameObject())
            {
                // Debug.Log( hit.transform.gameObject.name );
                // if clicked on one of the prefab objects, set the current object to the most recent clicked one
                if(ObjectList.objects.Contains(hit.transform.gameObject.name)) 
                {
                    selectedGameObject = hit.transform.gameObject;
                    Debug.Log( "Hooray" + selectedGameObject.name);
                    showColorMenu();
                }
            }
        }
    }

    public void showColorMenu() 
    { 
        menu.SetActive(true);
    }

    public void setColor(int i)
    {
        setColor(colors[i]);
    }

    void setColor(Color color)
    {
        selectedGameObject.GetComponent<Renderer>().material.color = color;
    }

    public void ExistColorChangeMenu()
    {
        menu.SetActive(false);
    }

}
