using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    

    public void OnSave()
    {
        SerializationManager.Save("objectsave", SaveData.current);
    }

    public void OnLoad()
    {
        // Tell the game to load (and the current game objects to be destroyed)
        GameEvents.current.dispatchOnLoadEvent();
        
        SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/objectsave.save");
       
        for(int i = 0; i < SaveData.current.objects.Count; i++)
        {
            ObjectData currentObject = SaveData.current.objects[i];
            GameObject obj = Instantiate(Spawner.GetSpawnObject(currentObject.objectid), currentObject.position, currentObject.rotation);
            ObjectHandler objectHandler = obj.GetComponent<ObjectHandler>();
            objectHandler.objectid = currentObject.objectid;
            objectHandler.transform.position = currentObject.position;
            objectHandler.transform.rotation = currentObject.rotation;
        }
    }
}