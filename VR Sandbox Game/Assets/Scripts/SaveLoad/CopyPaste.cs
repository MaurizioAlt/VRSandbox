using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CopyPaste : MonoBehaviour
{
    public GameObject copyObject;

    public static HashSet<string> savedObjects = new HashSet<string>();

    public void Copy()
    {
        copyObject = EditMenu.selectedGameObject;
    }
    public void Paste()
    {
        Instantiate(copyObject, Camera.main.transform.position + Camera.main.transform.forward * 5, copyObject.transform.rotation);
    }
}
