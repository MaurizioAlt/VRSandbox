using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectProperties : MonoBehaviour
{
    private Color[] colors = {Color.red,       
                                Color.yellow,     
                                Color.blue,     
                                Color.green,     
                                Color.cyan,    
                                Color.white};
    private int colorIdx = 0;

    void Start() 
    {   
        initColor();
    }

    void OnMouseUpAsButton() 
    { 
        setColor(nextColor());
    }

    void setColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

    Color nextColor()
    {
        colorIdx = (colorIdx + 1) % colors.Length;
        Debug.Log("color idx: " + colorIdx);
        return colors[colorIdx];
    }

    void initColor()
    {
        Color color = GetComponent<Renderer>().material.color;
        for(int i = 0; i < colors.Length; i++)
        {
            if(color == colors[i]) 
            {
                colorIdx = i;
                break;
            }
        }   
    }
}
