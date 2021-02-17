using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveLoad : MonoBehaviour
{
    public GameObject[] savedObjectPrefab;

    // public static HashSet<string> savedObjects = new HashSet<string>();
    // void Start()
    // {
    //     // add name of objects that going to be spawned
    //     savedObjects.Add("1");
    //     savedObjects.Add("2");
    //     savedObjects.Add("3");
    //     savedObjects.Add("4");
    //     savedObjects.Add("5");
    // }

    public void Save(int i)
    {
        if(EditMenu.selectedGameObject == null)
        {
            // add message to tell users to select the desired object
            Debug.Log("SaveLoad >>> Save() >>> no object selected");
            return;
        }
        string name = EditMenu.selectedGameObject.name + "(Clone)";
        if(savedObjectPrefab[i] != null) 
        {
            Debug.Log("SaveLoad >>> Save() >>> overwrite saved object from: " + savedObjectPrefab[i].name + " to " + name);
            ObjectList.objects.Remove(name);
        }
        // add the object to object list so the user can change the object property
        ObjectList.objects.Add(name);
        savedObjectPrefab[i] = EditMenu.selectedGameObject;
        string path = "Assets/" + "prefab" + i + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(EditMenu.selectedGameObject, path);

    }
    public void Load(int i)
    {
        if(savedObjectPrefab[i] == null) 
        {
            // add message to let the user know nothing save there
            Debug.Log("SaveLoad >>> Load() >>> no object at the slot");
            return;
        }
        Debug.Log("SaveLoad >>> Load() >>> load object: " + savedObjectPrefab[i]);
        string path = "Assets/" + "prefab" + i + ".prefab";
        Instantiate(savedObjectPrefab[i], Camera.main.transform.position + Camera.main.transform.forward * 5, savedObjectPrefab[i].transform.rotation);
    }
}
