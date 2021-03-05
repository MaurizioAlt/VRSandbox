using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveLoad : MonoBehaviour
{
    public GameObject[] savedObjectPrefab;

    public static HashSet<string> savedObjects = new HashSet<string>();
    void Start()
    {
        // add name of objects that going to be spawned
        savedObjects.Add("1");
        savedObjects.Add("2");
        savedObjects.Add("3");
        savedObjects.Add("4");
        savedObjects.Add("5");
    }

    public void Save(int i)
    {
        savedObjectPrefab[i] = EditMenu.selectedGameObject;
        string path = "Assets/Prefabs/" + "Custom" + i + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(EditMenu.selectedGameObject, path);
    }
    public void Load(int i)
    {
        string path = "Assets/" + "prefab" + i + ".prefab";
        Instantiate(savedObjectPrefab[i], Camera.main.transform.position + Camera.main.transform.forward * 5, savedObjectPrefab[i].transform.rotation);
    }
}
