using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    private static SaveData _current;
    public static SaveData current
    {
        get
        {
            if(_current == null)
            {
                _current = new SaveData();
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
        SerialManager.Save("objectsave", SaveData.current);
    }

    public static void OnLoad()
    {
        //GameEvents

        SaveData.current = (SaveData)SerialManager.Load(Application.persistentDataPath + "/saves/Save.save");
        
        for(int i = 0; i < SaveData.current.objectOne.Count; i++)
        {
            ObjectData currentObj = SaveData.current.objectOne[i];
            GameObject obj = EditMenu.selectedGameObject;
            ObjectHandler objectHandler = obj.GetComponent<ObjectHandler>();
            objectHandler.objectData = currentObj;
            objectHandler.transform.position = currentObj.position;
            objectHandler.transform.rotation = currentObj.rotation;
        }

    }

    public List<ObjectData> objectOne;

}