using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangePosition : MonoBehaviour, IPointerUpHandler
{
    public GameObject menu;
    public Slider slider;

    public void showPositionMenu()
    {
        menu.SetActive(true);
    }

    public void increasePositionX()
    {
        EditMenu.selectedGameObject.transform.position += new Vector3(1, 0, 0);
    }
    public void increasePositionY()
    {
        EditMenu.selectedGameObject.transform.position += new Vector3(0, 1, 0);
    }
    public void increasePositionZ()
    {
        EditMenu.selectedGameObject.transform.position += new Vector3(0, 0, 1);
    }
    public void decreasePositionX()
    {
        EditMenu.selectedGameObject.transform.position += new Vector3(-1, 0, 0);
    }
    public void decreasePositionY()
    {
        EditMenu.selectedGameObject.transform.position += new Vector3(0, -1, 0);
    }
    public void decreasePositionZ()
    {
        EditMenu.selectedGameObject.transform.position += new Vector3(0, 0, -1);
    }

    public void ExitPositionChangeMenu()
    {
        menu.SetActive(false);
    }

    public void rotatePositiveX()
    {
        EditMenu.selectedGameObject.transform.Rotate(45f, 0f, 0f);
    }
    public void rotateNegativeX()
    {
        EditMenu.selectedGameObject.transform.Rotate(-45f, 0f, 0f);
    }
    public void rotatePositiveY()
    {
        EditMenu.selectedGameObject.transform.Rotate(0f, 45f, 0f);
    }
    public void rotateNegativeY()
    {
        EditMenu.selectedGameObject.transform.Rotate(0f, -45f, 0f);
    }
    public void rotatePositiveZ()
    {
        EditMenu.selectedGameObject.transform.Rotate(0f, 0f, 45f);
    }
    public void rotateNegativeZ()
    {
        EditMenu.selectedGameObject.transform.Rotate(0f, 0f, -45f);
    }


    float oldValue;
    public void OnPointerUp(PointerEventData eventData)
    {
        if (slider.value != oldValue)
        {
            Debug.Log("Slider value changed from " + oldValue + " to " + slider.value);
            oldValue = slider.value;
        }
    }

    public void sliderincreasePositionX()
    {
        oldValue = slider.value;
        EditMenu.selectedGameObject.transform.position += new Vector3(slider.value, 0, 0);
        slider.value = 0;
    }
}
