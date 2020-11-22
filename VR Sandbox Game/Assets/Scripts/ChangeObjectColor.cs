﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectColor : MonoBehaviour
{
    public GameObject colorChangeMenu;
    public static GameObject selectedGameObject;

    void Update()
    {
        if( Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            RaycastHit hit;
            
            if( Physics.Raycast( ray, out hit, 100 ) )
            {
                Debug.Log( hit.transform.gameObject.name );
                if(ObjectList.objects.Contains(hit.transform.gameObject.name)) 
                {
                    selectedGameObject = hit.transform.gameObject;
                    Debug.Log( "Hooray" + selectedGameObject.name);
                    showColorMenu();
                }
            }
        }
    }

    private Color[] colors = {Color.red,            // #FFFF0000    0
                                Color.yellow,       // #FFFFFF00    1
                                Color.blue,         // #FF0000FF    2
                                Color.green,        // #FF008000    3
                                Color.cyan,         // #FF00FFFF    4
                                Color.white};       // #FFFFFFFF    5

    public void showColorMenu() 
    { 
        //setColor(nextColor());
        colorChangeMenu.SetActive(true);
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
        colorChangeMenu.SetActive(false);
    }
}
