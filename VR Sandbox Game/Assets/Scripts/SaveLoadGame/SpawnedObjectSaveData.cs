using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnedObjectSaveData 
{
    private static SpawnedObjectSaveData _current;
    public static SpawnedObjectSaveData current
    {
        get
        {
            if(_current == null)
            {
                _current = new SpawnedObjectSaveData();
            }

            return _current;
        }
        set
        {
            if (value != null)
            {
                _current = value;
            }
        }
    }

    public static void OnSave()
    {
        SerialManager.Save("objectsave", SpawnedObjectSaveData.current);
    }

    // public static void OnLoad()
    // {

    //     SpawnedObjectSaveData.current = (SpawnedObjectSaveData)SerialManager.Load(Application.persistentDataPath + "/saves/Save.save");
        
    //     for(int i = 0; i < SpawnedObjectSaveData.current.spawnedObjects.Count; i++)
    //     {
    //         SpawnedObectData currentObj = SpawnedObjectSaveData.current.spawnedObjects[i];
    //         GameObject obj = EditMenu.selectedGameObject;
    //         ObjectHandler objectHandler = obj.GetComponent<ObjectHandler>();
    //         objectHandler.objectData = currentObj;
    //         objectHandler.transform.position = currentObj.position;
    //         objectHandler.transform.rotation = currentObj.rotation;
    //     }

    // }

    public List<SpawnedObjectData> spawnedObjects;

}