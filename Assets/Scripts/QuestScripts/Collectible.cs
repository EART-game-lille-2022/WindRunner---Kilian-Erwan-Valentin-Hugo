using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static List<Collectible> collectibles = new List<Collectible>();
    
    public string objectID;

    public Transform objectToFollow;
    public Vector3 offset;

    void Awake() {
        collectibles.Add(this);
        gameObject.SetActive(false);
    }

    void OnDestroy() {
        collectibles.Remove(this);
    }
    void Update()
    { 
        transform.position = objectToFollow.position + offset;
    }
}
