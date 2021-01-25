using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    public static HashSet<string> objects = new HashSet<string>();

    void Start()
    {
        // add name of objects that going to be spawned
        objects.Add("Cube(Clone)");   
        objects.Add("Capsule(Clone)");   
        objects.Add("Cylinder(Clone)");   
        objects.Add("Sphere(Clone)");   
        objects.Add("TriangularPrism(Clone)");   
    }
}
