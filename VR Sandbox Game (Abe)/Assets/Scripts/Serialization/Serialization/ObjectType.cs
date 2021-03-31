using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ObjectType
{
    Sphere,
    Cube,
    Prism,
    Capsule,
    Cylinder
}

[System.Serializable]
public class ObjectData
{
    public string id;

    public ObjectType objectType;

    public Vector3 position;

    public Quaternion rotation; 
}