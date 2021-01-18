using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeObjectColor : MonoBehaviour
{
    public GameObject menu;
    public GameObject menu2;
    public Color[] colors;


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
        EditMenu.selectedGameObject.GetComponent<Renderer>().material.color = color;
    }

    public void ExistColorChangeMenu()
    {
        menu.SetActive(false);
    }

}
