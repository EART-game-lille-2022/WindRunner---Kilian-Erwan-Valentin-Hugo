using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFinder : MonoBehaviour
{

    public static List<ObjectFinder> objects = new List<ObjectFinder>();

    public string ID;
    
    public void OnEnable() {
        objects.Add(this);
    }
    public void OnDisable() {
        objects.Remove(this);
    }

    public static GameObject Find(string name) {
        foreach (ObjectFinder obj in objects) {
            if (obj.name == name)
                return obj.gameObject;
        }
        return null;
    }
}
