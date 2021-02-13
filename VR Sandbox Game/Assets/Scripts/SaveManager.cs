using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class SaveManager : MonoBehaviour
{
    // public TMP_InputField saveName;
    // public GameObject loadButtonPrefab;

    // public void OnSave()
    // {
    //     // SerializationManager.Save(saveName.text, SaveData.current);
    // }

    // public string[] saveFiles;
    // public void GetLoadFiles()
    // {
    //     if(!Directory.Exists(Application.persistentDataPath + "/saves/"))
    //     {
    //         Directory.CreateDirectory(Application.persistentDataPath + "/saves");
    //     }

    //     saveFiles = Directory.GetFiles(Application.persistentDataPath + "/saves/");
    // }

    // // not sure if the below function is in this .cs file from the video
    // public void ShowLoadScreen()
    // {
    //     GetLoadFiles();
        
        // foreach(Transform button in loadArea)
        // {
        //     Destroy(button.gameObject);
        // }

        // for(int i = 0; i < saveFiles.Length; i++)
        // {
        //     GameObject buttonObject = Instantiate(loadButtonPrefab);
        //     buttonObject.transform.SetParent(loadArea.transform, false);

        //     var index = i;
        //     buttonObject.GetComponent<Button>().onClick.AddListener(() =>
        //     {
        //         ToyManager.OnLoad(saveFiles[index]);
        //     });
        //     buttonObject.GetComponentInChildren<TextMeshProUGUI>().text = saveFiles[index].Replace(Application.persistentDataPath + "/saves/", "");
        // }
    // }

    // // below code is not tested, attempt to grab all the objects user spawned in hierarchy
    // public List<GameObject> GetSpawnedObjects()
    // {
    //     List<GameObject> objList = new List<GameObject>();

    //     foreach(GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
    //     {
    //         Debug.Log("found object: " + obj.name + " from code SaveManager.cs > GetSpawnedObjects");
    //         if(ObjectList.objects.Contains(obj.name))
    //         {
    //             objList.Add(obj);
    //         }
    //     }

    //     return objList;
    // }
}