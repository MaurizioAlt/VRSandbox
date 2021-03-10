using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Valve.VR;
using System;
using UnityEngine.Events;

[Serializable]

public class ColorEvent : UnityEvent<Color> { }
public class Picker : MonoBehaviour
{
    public SteamVR_Action_Boolean m_GrabAction = null;
    private SteamVR_Behaviour_Pose m_Pose = null;


    public TextMeshProUGUI DebugText;
    public ColorEvent OnColorPreview;
    public GameObject ColorPick;
    public Material sampleMatt;
    public Material matt;

    public bool pickingColor;
    //public MeshRenderer m_Renderer;

    Color selectedColor;

    //[SerializeField] private Renderer Object;
    RectTransform Rect;
    Texture2D ColorTexture;
    public ColorEvent OnColorSelect;
    void Awake()
    {
        Rect = ColorPick.GetComponent<RectTransform>();
        ColorTexture = ColorPick.GetComponent<Image>().mainTexture as Texture2D;
        
        m_Pose = GetComponent<SteamVR_Behaviour_Pose>();

        //gameObject.GetComponent<MeshRenderer>().material.SetColor(“_BaseColor”, theColor);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Vector2 delta;

       

            if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Test") && m_GrabAction.GetState(m_Pose.inputSource))
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, hit.point, null, out delta);

                Debug.Log("Picking color");

                string debug = "Position = " + hit.point;
                debug += "<br>delta = " + delta;
                

                float width = Rect.rect.width;
                float height = Rect.rect.height;

                delta += new Vector2(width * .5f, height * .5f);
                debug += "<br>offset delta = " + delta;

                float x = Mathf.Clamp(delta.x / width, 0f, 1f);
                float y = Mathf.Clamp(delta.x / height, 0f, 1f);

                debug += "<br>x=" + x + "y="+ y;

                int texX = Mathf.RoundToInt(x * ColorTexture.width);
                int texY = Mathf.RoundToInt(y * ColorTexture.width);
                
                debug += "<br>texX=" + texX + "texY=" + texY;

                Color color = ColorTexture.GetPixel(texX, texY);
                sampleMatt.color = color;

                DebugText.color = color;
                DebugText.text = debug;

                selectedColor = color;

                OnColorPreview?.Invoke(color);                    
            }
            if (hit.collider.gameObject.CompareTag("InteractableObject") && m_GrabAction.GetStateDown(m_Pose.inputSource) && pickingColor)
            {
                hit.transform.gameObject.GetComponent<Renderer>().material.color = selectedColor;
            }

          //  if (hit.collider.gameObject.CompareTag("Object"))
          // {
          //Fetch the mesh renderer component from the GameObject
          //m_Renderer = GetComponent<MeshRenderer>();
          //Object.material.color = sampleMatt.color;

                //   if (m_GrabAction.GetState(m_Pose.inputSource))
                //  {
                //Debug.Log(m_Renderer);
                //m_Renderer.GetComponent<MeshRenderer>().sharedMaterial.SetColor("_Color", sampleMatt.color);              
                //   }
                //  } 

        }           
    }
}
