using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeSize : MonoBehaviour
{
    public GameObject menu;

    public void showResizeMenu()
    {
        menu.SetActive(true);
    }

    public void increaseX()
    {
            EditMenu.selectedGameObject.transform.localScale += new Vector3(1, 0, 0);
    }
    public void increaseY()
    {
        EditMenu.selectedGameObject.transform.localScale += new Vector3(0, 1, 0);
    }
    public void increaseZ()
    {
        EditMenu.selectedGameObject.transform.localScale += new Vector3(0, 0, 1);
    }
    public void decreaseX()
    {
        if (EditMenu.selectedGameObject.transform.localScale.x > 1.0f)
        {
            EditMenu.selectedGameObject.transform.localScale += new Vector3(-1, 0, 0);
        }
    }
    public void decreaseY()
    {
        if (EditMenu.selectedGameObject.transform.localScale.y > 1.0f)
        {
            EditMenu.selectedGameObject.transform.localScale += new Vector3(0, -1, 0);
        }
    }
    public void decreaseZ()
    {
        if (EditMenu.selectedGameObject.transform.localScale.z > 1.0f)
        {
            EditMenu.selectedGameObject.transform.localScale += new Vector3(0, 0, -1);
        }
    }

    public void increaseAll()
    {
        EditMenu.selectedGameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }
    public void decreaseAll()
    {
        if (EditMenu.selectedGameObject.transform.localScale.x > 1.0f && EditMenu.selectedGameObject.transform.localScale.y > 1.0f && EditMenu.selectedGameObject.transform.localScale.z > 1.0f)
        {
            EditMenu.selectedGameObject.transform.localScale += new Vector3(-0.1f, -0.1f, -0.1f);
        }
    }

    public void ExitResizeMenu()
    {
        menu.SetActive(false);
    }

}
